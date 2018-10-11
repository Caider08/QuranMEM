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
                

                Navigation.PushAsync(new HomePage());
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!String.IsNullOrEmpty(App.user.Email))
            {
                Navigation.PushAsync(new HomePage());
            }

        }

        private void Exit_Clicked(object sender, EventArgs e)
        {

        }
    }
}
