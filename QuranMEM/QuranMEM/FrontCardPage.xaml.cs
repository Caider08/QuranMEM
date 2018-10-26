using Newtonsoft.Json.Linq;
using QuranMEM.Model;
using QuranMEM.ViewModel;
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
	public partial class FrontCardPage : ContentPage
	{
        FlashCardViewModel fcVM;

		public FrontCardPage ()
		{
			InitializeComponent ();

            fcVM = new FlashCardViewModel();

            BindingContext = fcVM;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(App.user.CurrentCard < 1 || App.user.CurrentCard > 6236)
            {
                Navigation.PushModalAsync(new NavigationPage(new HomePage()));

            }

            NavigationPage.SetHasNavigationBar(this, false);

            /* var verseNumba = App.user.CurrentCard;

             string urlArabic = "http://api.alquran.cloud/ayah/" + App.user.CurrentCard;

             string verse = "";

             using (var wb = new WebClient())
             {
                 var response = wb.DownloadString(urlArabic);

                 var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                 verse += quranObject.data.text;

                 System.Threading.Thread.Sleep(150);

             }*/

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }


            private async void BackFlashCard_Clicked(object sender, EventArgs e)
        {

            try
            {
                await Navigation.PushAsync(new BackCardPage(fcVM));
            }
            catch(Exception englishTranslationE)
            {
                //Do Something
                await DisplayAlert("Error Back Card", "Error Navigating to Back of Card", "Try Again");
            }

        }

        private async void AccountScreen_Clicked(object sender, EventArgs e)
        {
            try
            {
                var answer = await DisplayAlert("Ayah Selection?", "Navigating back to selection screens will clear your currently selected Verses.", "Select new Ayahs", "Stay Here");
                if(answer)
                {
                    App.user.SelectedCards = new List<int>();

                    await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                }
                             
            }
            catch(Exception verseSelectionNavigation)
            {
                //Do Something
                await DisplayAlert("Error Navigating", "Error navigating back to Home Screen", "Try Again");
            }

        }
    }
}