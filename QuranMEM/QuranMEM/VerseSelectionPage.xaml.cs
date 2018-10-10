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

       

        protected override void OnAppearing()
        {
       
        
            base.OnAppearing();

            var chapters = new List<SurahDatum>();

            string surahURL = "http://api.alquran.cloud/surah";



            //string chapterName = "";
            try
            {

                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(surahURL);

                    var quranObject = JToken.Parse(response).ToObject<SurahRootObject>();

                    chapters = quranObject.data;

                }

                verseListView.ItemsSource = chapters;
            }
            catch(Exception onAppearingE)
            {
                //Do something
                System.Threading.Thread.Sleep(150);
                Navigation.PushAsync(new VerseSearchPage());
            }
        }

        private void verseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            SurahDatum easy = (SurahDatum)e.SelectedItem;        
          
            var numberAyahs = easy.numberOfAyahs;

            var chapterNumba = easy.number.ToString();

            var chapterName = easy.englishNameTranslation;

            var url = "http://api.alquran.cloud/surah/" + chapterNumba + "/en.sahih";

            var ayahs = new List<Ayah>();

            if(App.user.SelectedCards == null)
            {
                App.user.SelectedCards = new List<int>();

                App.user.IncorrectCards = new List<int>();
            }

            //string chapterName = "";
            try
            {

                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(url);

                    var quranObject = JToken.Parse(response).ToObject<RootObject>();

                    ayahs = quranObject.data.ayahs;

                }
       

                foreach (Ayah aya in ayahs)
                {
                    App.user.SelectedCards.Add(aya.number);
                }

                var preSelection = App.user.SelectedCards;

                App.user.CurrentCard = App.user.SelectedCards.FirstOrDefault();

                App.user.SelectedCards.Remove(App.user.CurrentCard);

                var afterSelection = App.user.SelectedCards;

                Navigation.PushAsync(new FrontCardPage());


            }
            catch(Exception verseSelectionE)
            {
                //Do Something
                //System.Threading.Thread.Sleep(250);
                App.user.SelectedCards = new List<int>();
            }

        }
    }
}