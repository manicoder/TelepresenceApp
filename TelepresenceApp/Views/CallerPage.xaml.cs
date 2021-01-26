using System;
using System.Collections.Generic;
using TelepresenceApp.CallHandler;
using TelepresenceApp.Utils;
using Xamarin.Forms;

namespace TelepresenceApp.Views
{
    public partial class CallerPage : ContentPage
    {
        ControlEventManager controlEventManager;
        public CallerPage()
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


        bool isCaller = false;
        private async void ControlEventManager_OnRecieved(object sender, EventArgs e)
        {
            var receiver = Convert.ToString(sender);
            if (!string.IsNullOrEmpty(receiver))
            {
                var receivedMsg = receiver.Split('_');
                var myUser = receivedMsg[0];
                var callerUser = receivedMsg[1];
                var msg = receivedMsg[2];

                if (AppUtility.MyUserId == myUser && msg == "New")
                {
                    AppUtility.CallerUserId = callerUser;
                    var action = await DisplayActionSheet(callerUser + " Want to connect", "", null, "Yes", "No");
                    if (action == "Yes")
                    {
                        if (!AppUtility.StartSession())
                        {
                            return;
                        }
                        isCaller = true;
                        controlEventManager.SendRequestControlEvents("_" + callerUser + "_Accept");
                        await Navigation.PushAsync(new CallPage());
                    }
                }
                else if (isCaller == false)
                {
                    if (AppUtility.MyUserId == callerUser && msg == "Accept")
                    {
                        await Navigation.PushAsync(new CallPage());
                    }
                }

            }

        }


        void ToCallerClick(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCallerUserId.Text))
            {
                AppUtility.CallerUserId = txtCallerUserId.Text;
                var reciever = AppUtility.CallerUserId + "_" + AppUtility.MyUserId + "_New";
                controlEventManager.SendRequestControlEvents(reciever);
            }
            else
            {
                DisplayAlert("Error", "Please enter caller id", "OK");
            }
        }
    }
}
