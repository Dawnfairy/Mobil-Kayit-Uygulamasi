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
    public partial class   OgrenciSayfasi: ContentPage
    {

        SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

        string Isim;
        int No;
        public OgrenciSayfasi(String OgrenciIsmi ,int OgrenciNo)
        {

            InitializeComponent();
            Isim = OgrenciIsmi;
            No = OgrenciNo;
            Title = OgrenciIsmi;
        }


        private void ÖğrenciBilgiButon(object sender, EventArgs e)
        {

            Navigation.PushAsync(new OgrenciBilgiSayfasi(Isim, No));

        }

        private void KayıtSilButon(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                


                Ogrenci ogrenciToDelete = conn.Table<Ogrenci>().FirstOrDefault(o => o.OgrenciNo == No);
                
                if (ogrenciToDelete != null)
                {

                 List<Ogrenci> Yaz = conn.Table<Ogrenci>().ToList();

                    foreach (var yazdir in Yaz)
                    {
                       
                        if (yazdir.OgrenciNo == No)
                        {
                           
  Navigation.PushAsync(new KullaniciSayfasi(yazdir.OgretmenAd));
                            

                        }

                    }

                    int rowsAffected = conn.Delete(ogrenciToDelete);
                    MessagingCenter.Send(this, "OgrenciSilindi");
                    Console.WriteLine("adas");
                    DisplayAlert("Başarılı", "Kayıt başarıyla silindi", "Tamam");

                }
                else
                {
                    DisplayAlert("Başarısız", "Kayıt silinemedi", "Tamam");
                }
            }


        }


    }
}