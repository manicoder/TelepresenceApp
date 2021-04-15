using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GCoreApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabControlView : ContentView
    {
        public event EventHandler OnTabClicked;

        public TabControlView()
        {
            InitializeComponent();
            joystick1.IsVisible = true;
            battery1.IsVisible = false;
            settings1.IsVisible = false;
            graph1.IsVisible = false;
            activity1.IsVisible = false;

            joystick.IsVisible = false;
            battery.IsVisible = true;
            settings.IsVisible = true;
            graph.IsVisible = true;
            activity.IsVisible = true;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            OnTabClicked?.Invoke(sender, e);

            var param = e as Xamarin.Forms.TappedEventArgs;
            switch (param.Parameter)
            {
                case "joystick":
                    joystick1.IsVisible = true;
                    battery1.IsVisible = false;
                    settings1.IsVisible = false;
                    graph1.IsVisible = false;
                    activity1.IsVisible = false;

                    joystick.IsVisible = false;
                    battery.IsVisible = true;
                    settings.IsVisible = true;
                    graph.IsVisible = true;
                    activity.IsVisible = true;
                    break;
                case "battery":
                    joystick1.IsVisible = false;
                    battery1.IsVisible = true;
                    settings1.IsVisible = false;
                    graph1.IsVisible = false;
                    activity1.IsVisible = false;

                    joystick.IsVisible = true;
                    battery.IsVisible = false;
                    settings.IsVisible = true;
                    graph.IsVisible = true;
                    activity.IsVisible = true;
                    break;
                case "settings":
                    joystick1.IsVisible = false;
                    battery1.IsVisible = false;
                    settings1.IsVisible = true;
                    graph1.IsVisible = false;
                    activity1.IsVisible = false;

                    joystick.IsVisible = true;
                    battery.IsVisible = true;
                    settings.IsVisible = false;
                    graph.IsVisible = true;
                    activity.IsVisible = true;
                    break;
                case "graph":
                    joystick1.IsVisible = false;
                    battery1.IsVisible = false;
                    settings1.IsVisible = false;
                    graph1.IsVisible = true;
                    activity1.IsVisible = false;

                    joystick.IsVisible = true;
                    battery.IsVisible = true;
                    settings.IsVisible = true;
                    graph.IsVisible = false;
                    activity.IsVisible = true;
                    break;
                case "activity":
                    joystick1.IsVisible = false;
                    battery1.IsVisible = false;
                    settings1.IsVisible = false;
                    graph1.IsVisible = false;
                    activity1.IsVisible = true;

                    joystick.IsVisible = true;
                    battery.IsVisible = true;
                    settings.IsVisible = true;
                    graph.IsVisible = true;
                    activity.IsVisible = false;
                    break;
                default:
                    break;
            }

        }
    }
}