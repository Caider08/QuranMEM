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

                string urlArabic = "http://api.alquran.cloud/ayah/" + user.CurrentCard;

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

        public string EnglishTranslation
        {
            get
            {             

                string urlArabic = "http://api.alquran.cloud/ayah/" + user.CurrentCard + "/en.sahih";

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

        public string ChapterName
        {
            get
            {
                             
                string url = "http://api.alquran.cloud/ayah/" + user.CurrentCard + "/en.sahih";

                string chapterName = "";

                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(url);

                    var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                    chapterName += quranObject.data.surah.englishNameTranslation;

                    System.Threading.Thread.Sleep(150);


                }

                return chapterName;
            }
        }

        public int ChapterNumba
        {
            get
            {
                string url = "http://api.alquran.cloud/ayah/" + user.CurrentCard + "/en.sahih";

                int chapterNumba;

                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(url);

                    var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                    chapterNumba = quranObject.data.surah.number;

                    System.Threading.Thread.Sleep(150);

                }

                return chapterNumba;
            }
        }

        public int VerseNumba
        {
            get
            {

                string url = "http://api.alquran.cloud/ayah/" + user.CurrentCard + "/en.sahih";

                int verseNumba;

                using (var wb = new WebClient())
                {
                    var response = wb.DownloadString(url);

                    var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                    verseNumba = quranObject.data.number;

                    System.Threading.Thread.Sleep(150);


                }

                return verseNumba;
            }
        }




    }
}
