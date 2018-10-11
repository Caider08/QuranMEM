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

        private string arabicVerse;

        public string ArabicVerse
        {
            get
            {
                try
                {
                    string currentCardString = user.CurrentCard.ToString();

                    string urlArabic = "http://api.alquran.cloud/ayah/" + currentCardString;

                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(urlArabic);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            response = wb.DownloadString(urlArabic);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        arabicVerse += quranObject.data.text;

                    }

                    return arabicVerse;
                }
                catch (Exception arabicVerseE)
                {
                    //Do Something
                    System.Threading.Thread.Sleep(150);
                    return arabicVerse;
                }
            }
        }

        private string nextArabicVerse;

        public string NextArabicVerse
        {
            get
            {
                try
                {
                    var nextVerse = (user.CurrentCard + 1);

                    string nextVerseString = nextVerse.ToString();

                    string urlArabic = "http://api.alquran.cloud/ayah/" + nextVerseString;

                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(urlArabic);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            //Try again
                            response = wb.DownloadString(urlArabic);

                            System.Threading.Thread.Sleep(150);

                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        nextArabicVerse += quranObject.data.text;

                    }

                    return nextArabicVerse;
                }
                catch (Exception nextArabicVerseE)
                {
                    //Do Something
                    System.Threading.Thread.Sleep(150);
                    return nextArabicVerse;
                }
            }
        }

        private string englishTranslation;

        public string EnglishTranslation
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();


                    string urlArabic = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";


                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(urlArabic);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            //Try again
                            response = wb.DownloadString(urlArabic);
                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        englishTranslation += quranObject.data.text;

                    }

                    return englishTranslation;

                }
                catch (Exception englishTranslationE)
                {
                    //Do Something
                    System.Threading.Thread.Sleep(150);
                    return englishTranslation;
                }
            }
        }

        private string chapterName;

        public string ChapterName
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();

                    string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";


                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(url);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            //Try Again
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        chapterName += quranObject.data.surah.englishNameTranslation;

                        chapterName += ": ";

                    }

                    return chapterName;
                }
                catch (Exception chapterNameE)
                {
                    //Do Something
                    System.Threading.Thread.Sleep(150);
                    return chapterName;
                }
            }
        }

        private int chapterNumba;

        public int ChapterNumba
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();

                    string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(url);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            //Try again
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        chapterNumba = quranObject.data.surah.number;


                    }

                    return chapterNumba;
                }
                catch (Exception chapterNumbaE)
                {
                    //Do Something
                    System.Threading.Thread.Sleep(150);
                    return chapterNumba;
                }

            }
        }

        private int verseNumba;

        public int VerseNumba
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();


                    string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";


                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(url);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        verseNumba = quranObject.data.number;

                        System.Threading.Thread.Sleep(150);

                    }

                    return verseNumba;
                }
                catch (Exception verseNumbaE)
                {
                    //Do Something
                    System.Threading.Thread.Sleep(150);
                    return verseNumba;
                }

            }
        }

        private string verseName;

        public string VerseName
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();

                    string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                    using (var wb = new WebClient())
                    {
                        var response = wb.DownloadString(url);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        verseName = quranObject.data.text;

                        System.Threading.Thread.Sleep(150);

                    }

                    return verseName;
                }
                catch (Exception verseNumbaE)
                {
                    //Do Something
                    System.Threading.Thread.Sleep(150);
                    return verseName;
                }
            }
        }
    






    }
}
