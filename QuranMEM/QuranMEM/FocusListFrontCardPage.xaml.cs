﻿using QuranMEM.ViewModel;
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

                await Navigation.PushAsync(new HomePage());

            }
        }

        private async void AccountScreen_Clicked(object sender, EventArgs e)
        {
            try
            {
                var answer = await DisplayAlert("Account Screen", "Back to Account Screen?", "Yes", "No");

                if (answer)
                {
                    await Navigation.PushAsync(new AccountPage());
                }
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