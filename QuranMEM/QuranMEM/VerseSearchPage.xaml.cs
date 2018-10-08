using Newtonsoft.Json.Linq;
using QuranMEM.Model;
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
	public partial class VerseSearchPage : ContentPage
	{
		public VerseSearchPage ()
		{
			InitializeComponent ();
		}

        private void QuranCloudSearch_Clicked(object sender, EventArgs e)
        {

            var verseNumba = int.Parse(CloudSearchVerse.Text.ToString().Trim());

            App.user.CurrentCard += verseNumba;

            Navigation.PushAsync(new FrontCardPage());

            /*string url = "http://api.alquran.cloud/ayah/" + verseNumba + "/en.asad";

            //string urlArabic = "http://api.alquran.cloud/ayah/262";

            string verse = "";

            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(url);

                var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                verse += quranObject.data.text;

                System.Threading.Thread.Sleep(150);


            }*/


        }
    }
}