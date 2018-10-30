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
	public partial class AboutPage : ContentPage
	{
		public AboutPage ()
		{
			InitializeComponent ();

            var assembly = typeof(AboutPage);

            aboutFront.Source = ImageSource.FromResource("QuranMEM.Assets.Images.aboutApp.jpg", assembly);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //try
            //{
                //var leaders = new List<User>();
                //IF Customer decides to re-implement Leaderboard
                //var leaders = (await App.MobileService.GetTable<User>().ToListAsync()).OrderByDescending(u => u.VersesStudied).Take(10);
                //leadersListView.ItemsSource = leaders;

            //}
            //catch(Exception verseLeadersE)
            //{
               // var leaders = new List<User>();
              //  leadersListView.ItemsSource = leaders;
           // }
        }

  
        private async void OutAboutPage_Clicked_1(object sender, EventArgs e)
        {
            if(App.user == null || String.IsNullOrEmpty(App.user.Email))
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());

                App.Current.MainPage.Navigation.PopAsync();

                //await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            else
            {
                await Navigation.PushModalAsync(new NavigationPage(new HomePage()));
            }
        }
    }
}