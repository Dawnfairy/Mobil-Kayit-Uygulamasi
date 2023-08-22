using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mobil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
         
        }

        private void Button_Kayıt(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OgrKayıt());
 
        }

        private void Button_Giriş(object sender, EventArgs e) => Navigation.PushAsync(new GirisSayfasi());

        private void Admin_Giriş(object sender, EventArgs e)
        {

            Navigation.PushAsync(new AdminGiris());

        }
    }
}
