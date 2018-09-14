using QuranMEM.Model;
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
	public partial class LogInPage : ContentPage
	{
		public LogInPage ()
		{
			InitializeComponent ();
		}

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailEntryLogIn.Text))
            {
                await DisplayAlert("Email Error", "Please Enter a Valid Email", "OK");

            }
            if (string.IsNullOrEmpty(passwordEntryLogIn.Text))
            {
                await DisplayAlert("Password Error", "Please Enter a Password", "OK");
            }

            bool canLogIn = await User.Login(emailEntryLogIn.Text, passwordEntryLogIn.Text);

            if(canLogIn)
            {
                await Navigation.PushAsync(new HomePage());

            }
            else
            {
                await DisplayAlert("Error", "Please Try Logging In again", "OK");
            }




        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new RegisterPage()));
        }
    }
}