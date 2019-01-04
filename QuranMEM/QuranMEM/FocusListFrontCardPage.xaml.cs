using QuranMEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuranMEM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FocusListFrontCardPage : ContentPage
	{
        FlashCardViewModel FlashCardViewModel;

		public FocusListFrontCardPage ()
		{
			InitializeComponent ();

            FlashCardViewModel = new FlashCardViewModel();

            BindingContext = FlashCardViewModel;
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (App.user.CurrentCard < 1 || App.user.CurrentCard > 6236)
            {

                await Navigation.PushModalAsync(new NavigationPage(new  HomePage()));

            }

           // NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private async void AccountScreen_Clicked(object sender, EventArgs e)
        {
            try
            {
                //var answer = await DisplayAlert("Home Screen", "Back to Home Screen?", "Yes", "No");

                //if (answer)
                //{
                    await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                //}
            }
            catch(Exception accountScreenNavE)
            {
                await DisplayAlert("Error Navigation", "Problem Navigating to Account Screen", "Ok");
            }
            
        }

        private void FocusListBackFlashCard_Clicked(object sender, EventArgs e)
        {

            try
            {
                Navigation.PushAsync(new FocusListBackCardPage(FlashCardViewModel));
            }
            catch (Exception englishTranslationE)
            {
                //Do Something
                System.Threading.Thread.Sleep(150);
            }

        }
    }
}