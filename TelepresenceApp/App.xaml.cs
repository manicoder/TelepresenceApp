using System;
using TelepresenceApp.Utils;
using TelepresenceApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TelepresenceApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            AppUtility.Init();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
