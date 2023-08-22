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
	public partial class AdminGiris : ContentPage
	{
		public AdminGiris ()
		{
			InitializeComponent ();
		}

        private void Admin_Sayfasi(object sender, EventArgs e)
        {

            bool sifrebosmu = string.IsNullOrEmpty(AdminŞifre.Text);

			if(sifrebosmu || AdminŞifre.Text != "3441")
			{

                DisplayAlert("!!!", "Hatalı Giriş", "Tamam");
            }
			else
			{
				Navigation.PushAsync(new AdminSecenek());

			}


			
        }

     
    }
}