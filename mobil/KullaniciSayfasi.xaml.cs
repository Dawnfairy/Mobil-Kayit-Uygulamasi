using mobil.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KullaniciSayfasi : TabbedPage
    {

        SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
        ObservableCollection<Ogrenci> ogrenciList;
        string OgrAd1;
        int No;
        public KullaniciSayfasi(string OgrAd)
        {
            MessagingCenter.Subscribe<OgrenciSayfasi>(this, "OgrenciSilindi", (sender) =>
            {

                List<Ogrenci> hedefOgrenciler = conn.Table<Ogrenci>().Where(ogrenci => ogrenci.OgretmenAd == OgrAd).ToList();
                ogrenciListView.ItemsSource = new ObservableCollection<Ogrenci>(hedefOgrenciler);

            });

            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            //////////////////////////////////////////////////////////
            this.OgrAd1 = OgrAd;
            // ListView için öğrenci listesini oluşturun ve bağlayın
            ogrenciList = new ObservableCollection<Ogrenci>();
            ogrenciListView.ItemsSource = ogrenciList;



            conn.CreateTable<Ogrenci>();

            List<Ogrenci> Yaz = conn.Table<Ogrenci>().ToList();      //verileri yazdırmak için

            foreach (var yazdir in Yaz)
            {


                if (yazdir.OgretmenAd == OgrAd)
                {

                    var yeniOgrenci = new Ogrenci { Ad = yazdir.Ad, Soyad = yazdir.Soyad, OgrenciNo = yazdir.OgrenciNo };
                    ogrenciList.Add(yeniOgrenci);
                    No = yazdir.OgrenciNo;



                }

            }



        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void KayıtOl_Clicked(object sender, EventArgs e)
        {

            bool BosMu0 = string.IsNullOrEmpty(AdK.Text);
            bool BosMu1 = string.IsNullOrEmpty(SoyadK.Text);
            bool BosMu2 = string.IsNullOrEmpty(DogumYılıK.Text);
            bool BosMu3 = string.IsNullOrEmpty(BoyK.Text);
            bool BosMu4 = string.IsNullOrEmpty(KiloK.Text);
            bool BosMu5 = string.IsNullOrEmpty(TelefonNoK.Text);
            bool BosMu6 = string.IsNullOrEmpty(AdresK.Text);


            if (BosMu0 || BosMu1 || BosMu2 || BosMu3 || BosMu4 || BosMu5 || BosMu6)
            {
                //boş bırakılamaz

            }
            else
            {
                int kilo;
                int.TryParse(KiloK.Text, out kilo);
                int boy;
                int.TryParse(BoyK.Text, out boy);
                int dogumyili;
                int.TryParse(DogumYılıK.Text, out dogumyili);
                Ogrenci ogrenci = new Ogrenci()
                {
                    Ad = AdK.Text,
                    Soyad = SoyadK.Text,
                    OgretmenAd = OgrAd1,

                    Telefon = TelefonNoK.Text,
                    Adres = AdresK.Text,
                    DogumYili = dogumyili,
                    Boy = boy,
                    Kilo = kilo,
                    OgrenciNo = No


                };

                conn.CreateTable<Ogrenci>();
                int rows = conn.Insert(ogrenci);

                if (rows > 0)
                {

                    List<Ogrenci> hedefOgrenciler = conn.Table<Ogrenci>().Where(ogrenci1 => ogrenci1.OgretmenAd == OgrAd1).ToList();
                    ogrenciListView.ItemsSource = new ObservableCollection<Ogrenci>(hedefOgrenciler);

                    /*
                    List<Ogrenci> Yaz = conn.Table<Ogrenci>().ToList();
                    string ad = AdK.Text;
                    string soyad = SoyadK.Text; 
                   int no = ogrenci.OgrenciNo;
                 var yeniOgrenci = new Ogrenci { Ad = ad, Soyad = soyad,OgrenciNo = no};
                 
                 ogrenciList.Add(yeniOgrenci);
                    */

                    DisplayAlert("Başarılı", "Kayıt başarı ile eklendi", "Tamam");
                }

                else
                {
                    DisplayAlert("Başarısız", "Kayıt eklenmedi", "Tamam");

                }


            }


        }

        private void ogrenciListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item is Ogrenci selectedOgrenci)
            {
                Navigation.PushAsync(new OgrenciSayfasi(selectedOgrenci.Ad, selectedOgrenci.OgrenciNo));

            }

        }




    }



}