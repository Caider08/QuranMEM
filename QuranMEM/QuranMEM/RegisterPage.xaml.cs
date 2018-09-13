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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                //We can register the user
                User user = new User()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text,
                };
                try
                {


                    await App.MobileService.GetTable<User>().InsertAsync(user);
                }
                catch (Exception ez)
                {
                    Console.WriteLine(ez);
                }

            }
            else
            {
               await DisplayAlert("Registration Error", "Passwords Don't Match!", "OK");
            }
        }
    }
}