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

        private  async void LogInButton_Clicked(object sender, EventArgs e)
        {
           

            bool isEmailEntry = string.IsNullOrEmpty(emailEntryLogIn.Text);
            bool isPasswordEntry = string.IsNullOrEmpty(passwordEntryLogIn.Text);

            if (isEmailEntry || isPasswordEntry)
            {
                if (isEmailEntry)
                {
                    await DisplayAlert("Blank Email", "Please enter a Valid Email", "Ok");
                }
                else
                {
                    await DisplayAlert("Blank Password", "Please enter a Valid Password", "Ok");
                }

            }
            else
            {
                var user = (await App.MobileService.GetTable<User>().Where(u => u.Email == emailEntryLogIn.Text).ToListAsync()).FirstOrDefault();

                if (user != null)
                {
                    if (user.Password == passwordEntryLogIn.Text)
                    {


                        await Navigation.PushAsync(new NavigationPage(new HomePage()));
                    }
                    else
                    {
                        await DisplayAlert("Incorrect Password", "Incorrect Password for this Email", "OK");
                    }

                    
                }
                else
                {
                    await DisplayAlert("No User Exists with that Email", "No User Exists with that Email", "OK");
                   // await Navigation.PushAsync(new NavigationPage(new RegisterPage()));
                }

                
            }




        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage(new RegisterPage()));
        }
    }
}