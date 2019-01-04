using Newtonsoft.Json.Linq;
using QuranMEM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuranMEM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JuzSelectionPage : ContentPage
	{
		public JuzSelectionPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            try
            {
                var chapters = new List<Ajza>();

                for (int i = 1; i < 31; i++)
                {
                    var ajza = new Ajza()
                    {
                        number = i,
                    };

                    chapters.Add(ajza);

                }

                juzListView.ItemsSource = chapters;
            }
            catch(Exception juzE)
            {
                try
                {

                    var chapters = new List<Ajza>();

                    for(int i=1; i < 31; i++)
                    {
                        var ajza = new Ajza()
                        {
                            number = i,
                        };

                        chapters.Add(ajza);
                        
                    }

                    juzListView.ItemsSource = chapters;
                }
                catch(Exception juzE2)
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
                          
        }

        private async void juzListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Ajza easy = (Ajza)e.SelectedItem;

            var numberAyahs = easy.number;

            var chapterNumba = easy.number.ToString();

            Random rand = new Random();

            if (App.user.SelectedCards == null)
            {
                App.user.SelectedCards = new List<int>();

                App.user.IncorrectCards = new List<int>();
            }
            if (App.user.SelectedCards.Count() > 0)
            {
                //Have to add CurrentCard back to Selected Cards

                App.user.SelectedCards.Add(App.user.CurrentCard);

            }

            //string chapterName = "";
            try
            {
                var url = "http://api.alquran.cloud/juz/" + chapterNumba + "/en.sahih";

                var ayahs = new List<JuzAyah>();

                string response = "";

                using (var wb = new WebClient())
                {
                    response = await wb.DownloadStringTaskAsync(url);

                    if (string.IsNullOrEmpty(response))
                    {
                        //Try it again
                        System.Threading.Thread.Sleep(1000);
                        response = await wb.DownloadStringTaskAsync(url);

                    }
                }

                var quranObject = JToken.Parse(response).ToObject<JuzRootObject>();

                ayahs = quranObject.data.ayahs;
       
                foreach (JuzAyah aya in ayahs)
                {
                    App.user.SelectedCards.Add(aya.number);
                }

                App.user.CurrentCard = App.user.SelectedCards.Skip(rand.Next(App.user.SelectedCards.Count())).FirstOrDefault();

                App.user.SelectedCards.Remove(App.user.CurrentCard);

                //var afterSelection = App.user.SelectedCards;

                var answer = await DisplayAlert("Juz Added", "Would you like to Add another Juz to your Study Session?(for best performance limit amount of Ajzaa you select)", "Add More", "Start Studying");

                if (answer == true)
                {
                    //Stay on Surah Selection
                    System.Threading.Thread.Sleep(150);
                }
                else
                {
                    await Navigation.PushModalAsync(new NavigationPage(new FrontCardPage()));
                }

            }
            catch (Exception verseSelectionE)
            {
                //try Again
                try
                {
                    var url = "http://api.alquran.cloud/juz/" + chapterNumba + "/en.sahih";

                    var ayahs = new List<JuzAyah>();

                    string response = "";

                    using (var wb = new WebClient())
                    {
                        response = await wb.DownloadStringTaskAsync(url);

                        if (string.IsNullOrEmpty(response))
                        {
                            //Try it again
                            System.Threading.Thread.Sleep(1000);
                            response = await wb.DownloadStringTaskAsync(url);

                        }
                    }

                    var quranObject = JToken.Parse(response).ToObject<JuzRootObject>();

                    ayahs = quranObject.data.ayahs;

                    foreach (JuzAyah aya in ayahs)
                    {
                        App.user.SelectedCards.Add(aya.number);
                    }

                    App.user.CurrentCard = App.user.SelectedCards.Skip(rand.Next(App.user.SelectedCards.Count())).FirstOrDefault();

                    App.user.SelectedCards.Remove(App.user.CurrentCard);

                    //var afterSelection = App.user.SelectedCards;

                    var answer = await DisplayAlert("Juz Added", "Would you like to Add another Juz to your Study Session?(for best performance limit amount of Ajzaa you select)", "Add More", "Start Studying");

                    if (answer == true)
                    {
                        //Stay on Surah Selection
                        System.Threading.Thread.Sleep(150);
                    }
                    else
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new FrontCardPage()));
                    }
                }
                catch (Exception juzSelectionEE)
                {
                    //Do Something                    
                    await DisplayAlert("Verse Error", "Problems adding Selected Juz...please Re-Start the process", "Try Again");
                    App.user.SelectedCards = new List<int>();
                    await Navigation.PushAsync(new HomePage());
                }
            }

        }
    }
}