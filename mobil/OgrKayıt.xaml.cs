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
    public partial class OgrKayıt : ContentPage
    {
        public OgrKayıt()
        {
            InitializeComponent();
        }

        private void OgrKayıtOl_Clicked(object sender, EventArgs e)
        {


            bool BosMu0 = string.IsNullOrEmpty(AdK.Text);
            bool BosMu1 = string.IsNullOrEmpty(SoyadK.Text);
            bool BosMu2 = string.IsNullOrEmpty(TelefonNoK.Text);
            bool BosMu3 = string.IsNullOrEmpty(KullanıcıAdıK.Text);
            bool BosMu4 = string.IsNullOrEmpty(ŞifreK.Text);

            if (BosMu0 || BosMu1 || BosMu2 || BosMu3 || BosMu4)
            {
                //boş bırakılamaz

            }
            else
            {
                Post Ogretmen = new Post()
                {
                    Ad = AdK.Text,
                    Soyad = SoyadK.Text,
                    TelefonNo = TelefonNoK.Text,
                    KullaniciAdi = KullanıcıAdıK.Text,
                    Sifre = ŞifreK.Text

                };

                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                conn.CreateTable<Post>();
                int rows = conn.Insert(Ogretmen);

                if (rows > 0)
                {
                    /*
                    List<Post> Yaz = conn.Table<Post>().ToList();      //verileri yazdırmak için
                    foreach (var yazdir in Yaz)
                    {               
                        

                        var studentInfo = $"{yazdir.Ad},{yazdir.Soyad}";
                        Console.WriteLine(studentInfo);
                


                    }
                    */
                    DisplayAlert("Başarılı", "Kayıt başarı ile eklendi", "Tamam");
                }

                else
                {
                    DisplayAlert("Başarısız", "Kayıt eklenmedi", "Tamam");

                }

                Navigation.PushAsync(new GirisSayfasi());
            }



        }
    }
}