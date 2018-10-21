using Newtonsoft.Json.Linq;
using QuranMEM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuranMEM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerseSearchPage : ContentPage
    {
        public VerseSearchPage()
        {
            InitializeComponent();
        }

        private async void QuranCloudSearch_Clicked(object sender, EventArgs e)
        {
            var regexItem = new Regex("^[0 - 9] *$");

            if (!regexItem.IsMatch(CloudSearchVerse.Text))
            {

                var verseNumba = int.Parse(CloudSearchVerse.Text.ToString().Trim());

                if (verseNumba > 0 && verseNumba < 6237)
                {

                    App.user.CurrentCard += verseNumba;

                    await Navigation.PushAsync(new FrontCardPage());

                    /*string url = "http://api.alquran.cloud/ayah/" + verseNumba + "/en.asad";

                    //string urlArabic = "http://api.alquran.cloud/ayah/262";

                    string verse = "";

                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(url);

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        verse += quranObject.data.text;

                        System.Threading.Thread.Sleep(150);


                    }*/
                }
                else
                {
                    await DisplayAlert("Entry Error", "Only numbers (1-6236) are allowed for Ayah search", "OK");
                }

            }
            else
            {
                await DisplayAlert("Entry Error", "Only numbers (1-6236) are allowed for Ayah search", "OK");

            }
        }





        private async void QuranCloudSearchJuz_Clicked(object sender, EventArgs e)
        {
           
            var regexItem = new Regex("^[0 - 9] *$");

            if (!regexItem.IsMatch(CloudSearchJuz.Text))
            {

                var juzNumba = int.Parse(CloudSearchJuz.Text.ToString().Trim());

                if (juzNumba < 30 && juzNumba > 0)
                {

                    var url = "http://api.alquran.cloud/juz/" + juzNumba.ToString() + "/en.sahih";

                    var ayahs = new List<JuzAyah>();

                    string response = "";

                    if (App.user.SelectedCards == null)
                    {
                        App.user.SelectedCards = new List<int>();

                    }
                    if (App.user.SelectedCards.Count() > 0)
                    {
                        //Have to add CurrentCard back to Selected Cards

                        App.user.SelectedCards.Add(App.user.CurrentCard);

                    }

                    //string chapterName = "";
                    try
                    {
                        using (var wb = new WebClient())
                        {
                            response = await wb.DownloadStringTaskAsync(url);

                            if (string.IsNullOrEmpty(response))
                            {
                                //Try it again
                                System.Threading.Thread.Sleep(1000);
                                response = await wb.DownloadStringTaskAsync(url);

                            }

                            var quranObject = JToken.Parse(response).ToObject<JuzRootObject>();

                            ayahs = quranObject.data.ayahs;

                        }


                        foreach (JuzAyah aya in ayahs)
                        {
                            App.user.SelectedCards.Add(aya.number);
                        }

                        App.user.CurrentCard = App.user.SelectedCards.FirstOrDefault();

                        App.user.SelectedCards.Remove(App.user.CurrentCard);

                        await Navigation.PushAsync(new FrontCardPage());

                    }



                    catch (Exception verseSelectionE)
                    {
                        //Do Something
                        await DisplayAlert("Juz Error", "Problems getting the verses for the selected Juz", "Try Again");
                        App.user.SelectedCards = new List<int>();
                        await Navigation.PushAsync(new VerseSearchPage());

                    }
                }
                else
                {
                    await DisplayAlert("Entry Error", "Only numbers (1-30) are allowed for Juz search", "OK");
                }
            }
            else
            {
                await DisplayAlert("Entry Error", "Only numbers 1-30 are allowed for Juz search", "OK");            

            }

        }

        private async void EntireQuran_Clicked(object sender, EventArgs e)
        {
            try
            {
                Random rand = new Random();

                if (App.user.SelectedCards == null)
                {
                    App.user.SelectedCards = new List<int>();
                }
                else
                {
                    for (int i = 1; i < 6327; i++)
                    {
                        App.user.SelectedCards.Add(i);
                    }

                    System.Threading.Thread.Sleep(150);

                    
                    App.user.CurrentCard = App.user.SelectedCards.Skip(rand.Next(App.user.SelectedCards.Count())).FirstOrDefault();

                    App.user.SelectedCards.Remove(App.user.CurrentCard);

                    await App.Current.MainPage.Navigation.PushAsync(new FrontCardPage());
                }
            }
            catch(Exception entireQuranE)
            {
                await App.Current.MainPage.Navigation.PushAsync(new VerseSearchPage());
            }
        }

        private async void SurahSelection_Clicked(object sender, EventArgs e)
        {
            try
            { 
                await Navigation.PushAsync(new VerseSelectionPage());
            }
            catch(Exception verseSelectE)
            {
                await DisplayAlert("Surahs Error", "Error loading Surahs...try again shortly", "OK");
            }
        }
    }
}