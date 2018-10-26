using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuranMEM.Model;

namespace QuranMEM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerseSelectionPage : ContentPage
	{
		public VerseSelectionPage ()
		{
			InitializeComponent ();
		}

        private void QuranCloudTest_Clicked(object sender, EventArgs e)
        {

            //string url = "http://api.alquran.cloud/ayah/262/en.asad";

            string url2 = "http://api.alquran.cloud/ayah/262";

            string verse = "";

            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(url2);

                var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                verse += quranObject.data.text;

                System.Threading.Thread.Sleep(150);
                             
            }

        }

        /*  using (var client = new HttpClient())
    using (var request = new HttpRequestMessage(HttpMethod.Get, Url))
    using (var response = await client.SendAsync(request, cancellationToken))
    {
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Model>>(content);
    }*/

        protected override async void OnAppearing()
        {
       
        
            base.OnAppearing();

            var chapters = new List<SurahDatum>();

            string surahURL = "http://api.alquran.cloud/surah";

            string response = "";
           
            //string chapterName = "";
            try
            {

                using (var wb = new WebClient())
                {
                    
                    response = await wb.DownloadStringTaskAsync(surahURL);

                 
                    if(string.IsNullOrEmpty(response))
                    {
                        //try the call again
                        System.Threading.Thread.Sleep(1500);

                        response = await wb.DownloadStringTaskAsync(surahURL);
                     
                    }

                    var quranObject = JToken.Parse(response).ToObject<SurahRootObject>();

                    chapters = quranObject.data;

                }

                verseListView.ItemsSource = chapters;
            }
            catch(Exception onAppearingE)
            {
                //Do something                                      
                //string chapterName = "";
                try
                {
                    chapters = new List<SurahDatum>();

                    surahURL = "http://api.alquran.cloud/surah";

                    response = "";


                    using (var wb = new WebClient())
                    {

                        response = await wb.DownloadStringTaskAsync(surahURL);


                        if (string.IsNullOrEmpty(response))
                        {
                            //try the call again
                            System.Threading.Thread.Sleep(1500);

                            response = await wb.DownloadStringTaskAsync(surahURL);

                        }

                        var quranObject = JToken.Parse(response).ToObject<SurahRootObject>();

                        chapters = quranObject.data;

                    }

                    verseListView.ItemsSource = chapters;
                }
                catch(Exception onAppearingEE)
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
        }

        private async void verseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SurahDatum easy = (SurahDatum)e.SelectedItem;        
          
            var numberAyahs = easy.numberOfAyahs;

            var chapterNumba = easy.number.ToString();

            var chapterName = easy.englishNameTranslation;

           
            if(App.user.SelectedCards == null)
            {
                App.user.SelectedCards = new List<int>();

                App.user.IncorrectCards = new List<int>();
            }
            if(App.user.SelectedCards.Count() > 0)
            {
                //Have to add CurrentCard back to Selected Cards

                App.user.SelectedCards.Add(App.user.CurrentCard);
              
            }

            //string chapterName = "";
            try
            {
                var url = "http://api.alquran.cloud/surah/" + chapterNumba + "/en.sahih";

                var ayahs = new List<Ayah>();

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

                    var quranObject = JToken.Parse(response).ToObject<RootObject>();

                    ayahs = quranObject.data.ayahs;

                }


                foreach (Ayah aya in ayahs)
                {
                    App.user.SelectedCards.Add(aya.number);
                }

                App.user.CurrentCard = App.user.SelectedCards.FirstOrDefault();

                App.user.SelectedCards.Remove(App.user.CurrentCard);

                //var afterSelection = App.user.SelectedCards;

                var answer = await DisplayAlert("Surah Added", "Would you like to Add another Surah to your Study Session?(for best performance limit amount of Surahs you select)", "Yes", "Start Studying");

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
                    var url = "http://api.alquran.cloud/surah/" + chapterNumba + "/en.sahih";

                    var ayahs = new List<Ayah>();

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

                        var quranObject = JToken.Parse(response).ToObject<RootObject>();

                        ayahs = quranObject.data.ayahs;

                    }


                    foreach (Ayah aya in ayahs)
                    {
                        App.user.SelectedCards.Add(aya.number);
                    }

                    App.user.CurrentCard = App.user.SelectedCards.FirstOrDefault();

                    App.user.SelectedCards.Remove(App.user.CurrentCard);

                    var afterSelection = App.user.SelectedCards;

                    var answer = await DisplayAlert("Surah Added", "Would you like to Add another Surah to your Study Session?", "Yes", "Start Studying");

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
                catch (Exception verseSelectionEE)
                {
                    //Do Something                    
                    await DisplayAlert("Verse Error", "Problems adding Selected Surahs...please Re-Start the process", "Try Again");
                    App.user.SelectedCards = new List<int>();
                    await Navigation.PushAsync(new HomePage());
                }
            }

        }
    }
}