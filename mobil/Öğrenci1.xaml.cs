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
    public partial class Öğrenci1 : ContentPage
    {
        public Öğrenci1(String Öğrenciismi)
        {
            InitializeComponent();
        }
    }
}