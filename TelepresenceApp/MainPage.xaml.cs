using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelepresenceApp.Utils;
using TelepresenceApp.Views;
using Xamarin.Forms;

namespace TelepresenceApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!AppUtility.StartSession())
            {
                return;
            }
            Navigation.PushAsync(new CallPage());
        }
    }
}
