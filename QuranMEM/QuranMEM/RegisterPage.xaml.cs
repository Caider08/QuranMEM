using QuranMEM.Model;
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
	public partial class RegisterPage : ContentPage
	{
        //RegisterViewModel RegisterViewModel;


		public RegisterPage ()
		{
			InitializeComponent ();

            //RegisterViewModel = new RegisterViewModel();

            //BindingContext = RegisterViewModel;
		}

       // private async void registerButton_Clicked(object sender, EventArgs e)
        //{
            /*if(passwordEntry.Text == confirmPasswordEntry.Text)
            {
                //We can register the user
               

                bool registerSucess = await User.RegisterUser(user);

                if (registerSucess)
                {
                    await Navigation.PushAsync(new HomePage());

                }
                else
                {
                    await DisplayAlert("Registration Error", "Registration Failed...Please Try Again", "OK");
                }

            }
            else
            {
               await DisplayAlert("Registration Error", "Passwords Don't Match!", "OK");
            }
            */
        //}
    }
}