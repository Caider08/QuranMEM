﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QuranMEM.Model
{
    /*public class QuranCloudResponse
    {
        public Meta Meta { get; set; }

        public QuranData QData { get; set; }

    }

    public class Meta
    {
        public int Code { get; set; }

        public string Status { get; set; }



    }

    public class QuranData
    {

    }*/

    public class Edition
    {
    public string identifier { get; set; }
    public string language { get; set; }
    public string name { get; set; }
    public string englishName { get; set; }
    public string format { get; set; }
    public string type { get; set; }
    }

public class Surah
{
    public int number { get; set; }
    public string name { get; set; }
    public string englishName { get; set; }
    public string englishNameTranslation { get; set; }
    public int numberOfAyahs { get; set; }
    public string revelationType { get; set; }
}


    public class Data
{
    public int number { get; set; }
    public string text { get; set; }
    public Edition edition { get; set; }
    public Surah surah { get; set; }
    public int numberInSurah { get; set; }
    public int juz { get; set; }
    public int manzil { get; set; }
    public int page { get; set; }
    public int ruku { get; set; }
    public int hizbQuarter { get; set; }
    public bool sajda { get; set; }
}

public class QuranRootObject
{
    public int code { get; set; }
    public string status { get; set; }
    public Data data { get; set; }
}

    public class Ajza
    {
        public int number { get; set; }

        private const string juz = "Juz";

        public string Juz 
        {
            get
            {
                return juz;
            }
        }
    }

    public class SurahDatum
    {
        public int number { get; set; }
        public string name { get; set; }
        public string englishName { get; set; }
        public string englishNameTranslation { get; set; }
        public int numberOfAyahs { get; set; }
        public string revelationType { get; set; }
    }

    public class SurahRootObject
    {
        public int code { get; set; }
        public string status { get; set; }
        public List<SurahDatum> data { get; set; }
    }   

public class Ayah
{
    public int number { get; set; }
    public string text { get; set; }
    public int numberInSurah { get; set; }
    public int juz { get; set; }
    public int manzil { get; set; }
    public int page { get; set; }
    public int ruku { get; set; }
    public int hizbQuarter { get; set; }
    public bool sajda { get; set; }
}

    public class JuzAyah
    {
        public int number { get; set; }
        public string text { get; set; }
        public Surah surah { get; set; }
        public int numberInSurah { get; set; }
        public int juz { get; set; }
        public int manzil { get; set; }
        public int page { get; set; }
        public int ruku { get; set; }
        public int hizbQuarter { get; set; }
        public object sajda { get; set; }
    }


    public class SurahData
{
    public int number { get; set; }
    public string name { get; set; }
    public string englishName { get; set; }
    public string englishNameTranslation { get; set; }
    public string revelationType { get; set; }
    public int numberOfAyahs { get; set; }
    public List<Ayah> ayahs { get; set; }
    public Edition edition { get; set; }
}

public class RootObject
{
    public int code { get; set; }
    public string status { get; set; }
    public SurahData data { get; set; }
}

    public class JuzData
    {
        public int number { get; set; }
        public List<JuzAyah> ayahs { get; set; }
        public Surah surahs { get; set; }
        public Edition edition { get; set; }
    }

    public class JuzRootObject
    {
        public int code { get; set; }
        public string status { get; set; }
        public JuzData data { get; set; }
    }

   
    public class SearchMatch
    {
        public int number { get; set; }
        public string text { get; set; }
        public Edition edition { get; set; }
        public Surah surah { get; set; }
        public int numberInSurah { get; set; }
    }

    public class SearchData
    {
        public int count { get; set; }
        public List<SearchMatch> matches { get; set; }
    }

    public class SearchRootObject
    {
        public int code { get; set; }
        public string status { get; set; }
        public SearchData data { get; set; }
    }

}
