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
	public partial class HomePage : TabbedPage
	{
        private HomeViewModel homePageVM;

		public HomePage ()
		{
			InitializeComponent ();

            homePageVM = new HomeViewModel();

            BindingContext = homePageVM;

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        private void AccountButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}