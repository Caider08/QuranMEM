using Newtonsoft.Json.Linq;
using QuranMEM.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace QuranMEM.ViewModel
{
    public class FlashCardViewModel
    {
        private User user;

        public string Email
        {
            get { return user.Email; }


        }

        public int CurrentCard
        {

            get { return user.CurrentCard; }

        }

        public FlashCardViewModel()
        {
          
            user = App.user;

        }

        public string ArabicVerse
        {
            get
            {
                
                var verseNumba = user.CurrentCard;

                string urlArabic = "http://api.alquran.cloud/ayah/" + App.user.CurrentCard;

                string verse = "";

                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(urlArabic);

                    var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                    verse += quranObject.data.text;

                    System.Threading.Thread.Sleep(150);


                }

                return verse;
            }
        }
            
            


    }
}
