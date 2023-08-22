using mobil.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
            
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OgrenciBilgiSayfasi : ContentPage
    {
        SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
        public OgrenciBilgiSayfasi(String OgrenciIsmi, int OgrenciNo)
        {
            InitializeComponent();
            
            conn.CreateTable<Ogrenci>();

            List<Ogrenci> Yaz = conn.Table<Ogrenci>().ToList();
            

            foreach (var yazdir in Yaz)
            {
                if (yazdir.OgrenciNo == OgrenciNo)

                {

                    no.Text = OgrenciNo.ToString();
                    ad.Text = yazdir.Ad;
                    soyad.Text = yazdir.Soyad;
                    dogumyılı.Text = yazdir.DogumYili.ToString();
                    boy.Text = yazdir.Boy.ToString();
                    kilo.Text = yazdir.Kilo.ToString();
                    tel.Text = yazdir.Telefon.ToString();
                    adres.Text = yazdir.Adres + "                       ";


                }

            }


        }
    }
}