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

                    string response = "";

                    arabicVerse = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(urlArabic);

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
                    //TryAgain
                    //arabicVerse += "Error getting Arabic Ayah";
                    //return arabicVerse;                 
                    try
                    {
                        string currentCardString = user.CurrentCard.ToString();

                        string urlArabic = "http://api.alquran.cloud/ayah/" + currentCardString;

                        string response = "";

                        arabicVerse = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(urlArabic);

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
                    catch (Exception arabicVerseEE)
                    {
                        //Do Something
                        arabicVerse += "Error getting Arabic Ayah";
                        return arabicVerse;
                    }
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

                    string response = "";

                    nextArabicVerse = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(urlArabic);

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
                    //Try Again
                    //nextArabicVerse += "Error Getting next Arabic Ayah";
                    //return nextArabicVerse;

                    try
                    {
                        var nextVerse = (user.CurrentCard + 1);

                        string nextVerseString = nextVerse.ToString();

                        string urlArabic = "http://api.alquran.cloud/ayah/" + nextVerseString;

                        string response = "";

                        nextArabicVerse = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(urlArabic);

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
                    catch (Exception nextArabicVerseEE)
                    {
                        //Do Something
                        nextArabicVerse += "Error Getting next Arabic Ayah";
                        return nextArabicVerse;
                    }
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

                    string response = "";

                    englishTranslation = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(urlArabic);

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
                    //Try Again
                    //englishTranslation += "Error getting the english translation for selected Ayah";
                   // return englishTranslation;

                    try
                    {
                        string currentCard = user.CurrentCard.ToString();


                        string urlArabic = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                        string response = "";

                        englishTranslation = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(urlArabic);

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
                    catch (Exception englishTranslationEE)
                    {
                        //Do Something
                        englishTranslation += "Error getting the english translation for selected Ayah";
                        return englishTranslation;
                    }
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

                    string response = "";

                    chapterName = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(url);

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
                    //Try Again
                    //chapterName += "Error getting Surah Name";
                    //return chapterName;

                    try
                    {
                        string currentCard = user.CurrentCard.ToString();

                        string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                        string response = "";

                        chapterName = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(url);

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
                    catch (Exception chapterNameEE)
                    {
                        //Do Something
                        chapterName += "Error getting Surah Name";
                        return chapterName;
                    }
                }
            }
        }

        private string chapterArabicName;

        public string ChapterArabicName
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();

                    string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                    string response = "";

                    chapterArabicName = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(url);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            //Try Again
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        chapterArabicName += quranObject.data.surah.name + " ";
                        

                    }

                    return chapterArabicName;
                }
                catch (Exception chapterNameE)
                {
                    //Try Again
                    //chapterName += "Error getting Surah Name";
                    //return chapterName;

                    try
                    {
                        string currentCard = user.CurrentCard.ToString();

                        string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                        string response = "";

                        chapterArabicName = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);

                            if (string.IsNullOrEmpty(response))
                            {
                                //Try Again
                                response = wb.DownloadString(url);

                                System.Threading.Thread.Sleep(150);
                            }

                            var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                            chapterArabicName += quranObject.data.surah.name;
                          
                        }

                        return chapterName;
                    }
                    catch (Exception chapterNameEE)
                    {
                        //Do Something
                        chapterName += "Error getting Arabic Surah Name";
                        return chapterArabicName;
                    }
                }
            }
        }

        private string chapterNumba;

        public string ChapterNumba
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();

                    string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                    string response = "";

                    chapterNumba = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(url);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            //Try again
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        chapterNumba = quranObject.data.surah.number.ToString();

                        chapterNumba += ": ";


                    }

                    return chapterNumba;
                }
                catch (Exception chapterNumbaE)
                {
                    //Do Something                   
                   // return chapterNumba;
                    try
                    {
                        string currentCard = user.CurrentCard.ToString();

                        string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                        string response = "";

                        chapterNumba = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);

                            if (string.IsNullOrEmpty(response))
                            {
                                //Try again
                                response = wb.DownloadString(url);

                                System.Threading.Thread.Sleep(150);
                            }

                            var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                            chapterNumba = quranObject.data.surah.number.ToString();

                            chapterNumba += ": ";


                        }

                        return chapterNumba;
                    }
                    catch (Exception chapterNumbaEE)
                    {
                        //Do Something
                        return chapterNumba;
                    }
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

                    string response = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(url);

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
                    //return verseNumba;

                    try
                    {
                        string currentCard = user.CurrentCard.ToString();


                        string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                        string response = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(url);

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
                    catch (Exception verseNumbaEE)
                    {
                        //Do Something
                        return verseNumba;
                    }
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

                    string response = "";

                    verseName = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(url);

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
                   // verseName += "Error getting Ayah Name";
                    //return verseName;
                    try
                    {
                        string currentCard = user.CurrentCard.ToString();

                        string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                        string response = "";

                        verseName = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(url);

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
                    catch (Exception verseNumbaEE)
                    {
                        //Do Something
                        verseName += "Error getting Ayah Name";
                        return verseName;
                    }
                }
            }
        }

        private int verseSurahNumba;

        public int VerseSurahNumba
        {
            get
            {
                try
                {
                    string currentCard = user.CurrentCard.ToString();

                    string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                    string response = "";

                    using (var wb = new WebClient())
                    {
                        response = wb.DownloadString(url);

                        System.Threading.Thread.Sleep(150);

                        if (string.IsNullOrEmpty(response))
                        {
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);
                        }

                        var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                        verseSurahNumba = quranObject.data.numberInSurah;

                        System.Threading.Thread.Sleep(150);

                    }

                    return verseSurahNumba;
                }
                catch (Exception verseSurahNumbaE)
                {
                    //Try Again
                   // verseName += "Error getting Ayah Name";
                    //return verseSurahNumba;

                    try
                    {
                        string currentCard = user.CurrentCard.ToString();

                        string url = "http://api.alquran.cloud/ayah/" + currentCard + "/en.sahih";

                        string response = "";

                        using (var wb = new WebClient())
                        {
                            response = wb.DownloadString(url);

                            System.Threading.Thread.Sleep(150);

                            if (string.IsNullOrEmpty(response))
                            {
                                response = wb.DownloadString(url);

                                System.Threading.Thread.Sleep(150);
                            }

                            var quranObject = JToken.Parse(response).ToObject<QuranRootObject>();

                            verseSurahNumba = quranObject.data.numberInSurah;

                            System.Threading.Thread.Sleep(150);

                        }

                        return verseSurahNumba;
                    }
                    catch (Exception verseSurahNumbaEE)
                    {
                        //Do Something
                    
                        return verseSurahNumba;
                    }
                }
            }
        }

    }
}
