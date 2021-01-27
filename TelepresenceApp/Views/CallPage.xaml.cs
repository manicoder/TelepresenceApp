using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TelepresenceApp.Utils;
using Xamarin.Forms;
using Xamarin.Forms.OpenTok;
using Xamarin.Forms.OpenTok.Service;
using Xamarin.Forms.Xaml;

namespace TelepresenceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallPage : ContentPage
    {
        public CallPage()
        {
            InitializeComponent();
            this.Title = AppUtility.MyUserId;
            CrossOpenTok.Current.MessageReceived += OnMessageReceived;
        }

        #region Calling
        private void OnEndCall(object sender, EventArgs e)
        {
            CrossOpenTok.Current.EndSession();
            CrossOpenTok.Current.MessageReceived -= OnMessageReceived;
            Navigation.PopAsync();
            Navigation.PopAsync();
        }
        #endregion

        #region Messaging
        private void OnMessage(object sender, EventArgs e)
        {
            CrossOpenTok.Current.SendMessageAsync($"Path.GetRandomFileName: {Path.GetRandomFileName()}");
            CrossOpenTok.Current.SendMessageAsync("Hello World");

        }

        private void OnMessageReceived(string message)
        {
            DisplayAlert("Random message received", message, "OK");
        }

        #endregion

        #region Camera functions
        private void OnSwapCamera(object sender, EventArgs e)
        {
            CrossOpenTok.Current.CycleCamera();
        }
        private void PauseVideo()
        {

        }
        #endregion

        void OnShareScreen(object sender, EventArgs e)
        {
            CrossOpenTok.Current.PublisherVideoType = CrossOpenTok.Current.PublisherVideoType == OpenTokPublisherVideoType.Camera
                ? OpenTokPublisherVideoType.Screen
                : OpenTokPublisherVideoType.Camera;
        }

        private bool _isRendererSet;
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Renderer")
            {
                _isRendererSet = !_isRendererSet;
                if (!_isRendererSet)
                {
                    OnEndCall(this, EventArgs.Empty);
                }
            }
        }

        private void OpenTokSubscriberView_SizeChanged(object sender, EventArgs e)
        {
            var a = sender as OpenTokPublisherView;
        }

        private void StackLayout_SizeChanged(object sender, EventArgs e)
        {
            var b = sender as StackLayout;
        }
    }
}
