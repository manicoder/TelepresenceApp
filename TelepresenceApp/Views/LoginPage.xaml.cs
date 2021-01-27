using System;
using System.Collections.Generic;
using TelepresenceApp.Utils;
using Xamarin.Forms;

namespace TelepresenceApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void OnLoginClick(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserId.Text))
            {
                AppUtility.MyUserId = txtUserId.Text;
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                this.DisplayAlert("Error", "Please enter Userid", "OK");
            }

        }
    }
}
