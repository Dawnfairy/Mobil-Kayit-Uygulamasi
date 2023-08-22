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
    public partial class AdminSecenek : ContentPage
    {
        public AdminSecenek()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());

        }

        private void OgrListeSayfası_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AdminSayfasi());

        }

        private void KayıtSayfası_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OgrKayıt());
        }
    }
}