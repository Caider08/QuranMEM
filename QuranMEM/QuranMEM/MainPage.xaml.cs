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

            //if(user != null)
           // {
                 Navigation.PushAsync(new NavigationPage(new LogInPage()));
           // }
            //else
            //{

           // }

        }
    }
}
