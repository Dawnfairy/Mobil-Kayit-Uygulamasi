using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobil.Model
{
    public class Ogrenci
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string OgretmenAd { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public int DogumYili { get; set; }
        public int Boy { get; set; }
        public int Kilo { get; set; }

        [PrimaryKey, AutoIncrement]
        public int OgrenciNo { get; set; }

    }
}