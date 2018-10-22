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

            //var backgroundImage = ImageSource.FromResource("QuranMEM.Assets.Images.APPFRONT.JPG", assembly);

            // BackgroundImage = ImageSource.FromResource("QuranMEM.Assets.Images.APPFRONT.JPG", assembly).ToString();

            // this.BackgroundImage = "QuranMEM.Assets.Images.APPFRONT.JPG";

            //this.BackgroundImage = backgroundImage.ToString();


            appFront.Source = ImageSource.FromResource("QuranMEM.Assets.Images.quranapp3.jpg", assembly);

        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            var user = App.user;

            if(string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                Navigation.PushAsync(new LogInPage());
            }
            else
            {
                if (App.user.SelectedCards.Count() > 0)
                {
                    Navigation.PushAsync(new FrontCardPage());
                }
                else
                {
                    Navigation.PushAsync(new HomePage());
                }

            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!String.IsNullOrEmpty(App.user.Email))
            {

                if (App.user.SelectedCards.Count() > 0)
                {
                    Navigation.PushAsync(new FrontCardPage());
                }
                else
                {
                    Navigation.PushAsync(new HomePage());
                }
                
            }

        }

        private async void About_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new AboutPage());
        }
    }
}
