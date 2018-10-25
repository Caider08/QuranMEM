using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuranMEM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            //quranIconImage.Source = ImageSource.FromResource("QuranMEM.Assets.Images.QuranLogo.PNG", assembly);

            appFront.Source = ImageSource.FromResource("QuranMEM.Assets.Images.quranapp3.jpg", assembly);

        }

        private async void Start_Clicked(object sender, EventArgs e)
        {
            var user = App.user;

            if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                await Navigation.PushAsync(new LogInPage());
            }
            else
            {
                if (App.user.SelectedCards.Count() > 0)
                {
                    await Navigation.PushModalAsync(new NavigationPage(new FrontCardPage()));
                }
                else
                {
                    await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                }

            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!String.IsNullOrEmpty(App.user.Email))
            {

                if (App.user.SelectedCards != null && App.user.SelectedCards.Count() > 0)
                {
                    Navigation.PushModalAsync(new NavigationPage(new FrontCardPage()));
                }
                else
                {
                    Navigation.PushModalAsync(new NavigationPage(new HomePage()));
                }
                
            }

        }

        private async void About_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
