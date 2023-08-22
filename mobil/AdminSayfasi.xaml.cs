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
    public partial class AdminSayfasi : ContentPage
    { 
        
        SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
        ObservableCollection<Post> Liste;
     

        public AdminSayfasi()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);


            Liste = new ObservableCollection<Post>();
            ogretmenListView.ItemsSource = Liste;
            conn.CreateTable<Post>();


            List<Post> List = conn.Table<Post>().ToList();
            foreach (var Ogretmenler in List)
            {

                var ogretmen = new Post { KullaniciAdi = Ogretmenler.KullaniciAdi, Ad = Ogretmenler.Ad, Soyad = Ogretmenler.Soyad, TelefonNo = Ogretmenler.TelefonNo};
                Liste.Add(ogretmen);

            }

        }


        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());

        }

        private void ogretmenListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {


            if (e.Item is Post selectedOgrenci)
            {
                
                Navigation.PushAsync(new AdminBilgiSayfasi(selectedOgrenci.KullaniciAdi));

            }


        }
    }
}
