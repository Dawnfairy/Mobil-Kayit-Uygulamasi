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
    public partial class GirisSayfasi : ContentPage
    {
        public GirisSayfasi()
        {
            InitializeComponent();
        }

        private void GirişYap_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new )

            bool AdBosMu = string.IsNullOrEmpty(KullanıcıGiriş.Text);
            bool SifreBosMu = string.IsNullOrEmpty(ŞifreGiriş.Text);

            if (AdBosMu || SifreBosMu)
            {


                //Şifre veya Ad boş

            }
            else
            {
                //Giriş yapıldı????
                SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                conn.CreateTable<Post>();

                List<Post> Liste = conn.Table<Post>().ToList();

                int flag = 0;

                foreach (var Ogretmenler in Liste)
                {


                    if (Ogretmenler.KullaniciAdi == KullanıcıGiriş.Text && Ogretmenler.Sifre == ŞifreGiriş.Text)
                    {


                        Navigation.PushAsync(new KullaniciSayfasi(Ogretmenler.KullaniciAdi));
                        flag = 1;

                    }


                }

                if (flag == 0)
                {
                    DisplayAlert("hatalı giriş", "şifre veya kullanıcı adı yanlış", "tamam");
                }





                //Giriş yapıldı????

            }


        }


    }
}