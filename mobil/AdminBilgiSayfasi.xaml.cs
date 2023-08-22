using mobil.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminBilgiSayfasi : ContentPage
    {
        SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
        ObservableCollection<Ogrenci> Liste;

        public AdminBilgiSayfasi(string OgretmenKullaniciAdi)
        {

            InitializeComponent();

            Liste = new ObservableCollection<Ogrenci>();
            OgrenciListView.ItemsSource = Liste;

            conn.CreateTable<Ogrenci>();
            List<Ogrenci> List = conn.Table<Ogrenci>().ToList();
            foreach (var Ogrenciler in List)
            {


                if (Ogrenciler.OgretmenAd == OgretmenKullaniciAdi)
                {
                    var ogrenci = new Ogrenci { Ad = Ogrenciler.Ad, Soyad = Ogrenciler.Soyad, OgrenciNo = Ogrenciler.OgrenciNo };
                    Liste.Add(ogrenci);

                }


            }

            Post ogretmen = conn.Table<Post>().FirstOrDefault(o => o.KullaniciAdi == OgretmenKullaniciAdi);

            string OgretmenAd;
            string OgretmenSoyad;
            if (ogretmen != null)
            {
                OgretmenAd = ogretmen.Ad;
                OgretmenSoyad = ogretmen.Soyad;
                Title = OgretmenAd + " " + OgretmenSoyad;
            }
            else
            {
                // Öğrenci veritabanında bulunamadı, hata durumu veya başka bir işlem yapmak istiyorsanız buraya uygun kodu ekleyin.
            }



        }


        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());

        }


        private void OgrenciListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            if (e.Item is Ogrenci selectedOgrenci)
            {

                Navigation.PushAsync(new AdminOgrenciBilgiSayfasi(selectedOgrenci.OgrenciNo));

            }


        }

    }
}