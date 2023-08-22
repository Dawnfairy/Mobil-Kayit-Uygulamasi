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
    public partial class AdminOgrenciBilgiSayfasi : ContentPage
    {

        SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

        public AdminOgrenciBilgiSayfasi(int no)
        {


            InitializeComponent();
            conn.CreateTable<Ogrenci>();

            Ogrenci ogrenci = conn.Table<Ogrenci>().FirstOrDefault(o => o.OgrenciNo == no);

            if (ogrenci != null)
            {

                BindingContext = ogrenci;
            }
            else
            {
                // Öğrenci veritabanında bulunamadı, hata durumu veya başka bir işlem yapmak istiyorsanız buraya uygun kodu ekleyin.
            }



        }
    }
}