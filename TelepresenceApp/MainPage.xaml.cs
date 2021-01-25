using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelepresenceApp.CallHandler;
using TelepresenceApp.Utils;
using TelepresenceApp.Views;
using Xamarin.Forms;

namespace TelepresenceApp
{
    public partial class MainPage : ContentPage
    {
        ControlEventManager controlEventManager;
        public MainPage()
        {
            InitializeComponent();
            controlEventManager = new ControlEventManager();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await controlEventManager.Init();
            controlEventManager.OnRecieved += ControlEventManager_OnRecieved;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            controlEventManager.OnRecieved -= ControlEventManager_OnRecieved;
        }

        private async void ControlEventManager_OnRecieved(object sender, EventArgs e)
        {
            if (AppUtility.MyUserId == AppUtility.CallerUserId)
            {
                var action = await DisplayActionSheet(AppUtility.CallerUserId + " Want to connect", "Cancel", null, "Yes");
                if (action)
                {

                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtMyUser.Text))
            {
                AppUtility.CallerUserId = txtUser.Text;
                AppUtility.MyUserId = txtMyUser.Text;
                callButton.IsVisible = true;

                if (!AppUtility.StartSession())
                {
                    return;
                }
                Navigation.PushAsync(new CallPage());
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            controlEventManager.SendRequestControlEvents(AppUtility.CallerUserId);
        }
    }
}
