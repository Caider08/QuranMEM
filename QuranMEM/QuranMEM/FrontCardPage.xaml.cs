using Newtonsoft.Json.Linq;
using QuranMEM.Model;
using QuranMEM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuranMEM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FrontCardPage : ContentPage
	{
        FlashCardViewModel fcVM;

		public FrontCardPage ()
		{
			InitializeComponent ();

            fcVM = new FlashCardViewModel();

            BindingContext = fcVM;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

           /* var verseNumba = App.user.CurrentCard;

            string urlArabic = "http://api.alquran.cloud/ayah/" + App.user.CurrentCard;
        
            string verse = "";

            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(urlArabic);

                var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                verse += quranObject.data.text;

                System.Threading.Thread.Sleep(150);


            }*/
            
        }

        private void BackFlashCard_Clicked(object sender, EventArgs e)
        {

            try
            {
                Navigation.PushAsync(new BackCardPage(fcVM));
            }
            catch(Exception englishTranslationE)
            {
                //Do Something
                System.Threading.Thread.Sleep(150);
            }

        }

        private void AccountScreen_Clicked(object sender, EventArgs e)
        {
            try
            {

                Navigation.PushAsync(new HomePage());
            }
            catch(Exception verseSelectionNavigation)
            {
                //Do Something
                System.Threading.Thread.Sleep(150);
            }


        }
    }
}