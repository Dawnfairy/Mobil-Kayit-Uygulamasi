using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobil.Model
{
    public class Post
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNo { get; set; }

        [PrimaryKey]
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
    }
}