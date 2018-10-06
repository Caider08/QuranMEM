using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuranMEM.Model;

namespace QuranMEM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VerseSelectionPage : ContentPage
	{
		public VerseSelectionPage ()
		{
			InitializeComponent ();
		}

        private void QuranCloudTest_Clicked(object sender, EventArgs e)
        {



            //string url = "http://api.alquran.cloud/ayah/262/en.asad";

            string url2 = "http://api.alquran.cloud/ayah/262";

            string verse = "";

            using (var wb = new WebClient())
            {
                var response = wb.DownloadString(url2);

                var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                verse += quranObject.data.text;

                System.Threading.Thread.Sleep(150);

               

                
            }



        }
    }
}