using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelepresenceApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TelepresenceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPage : MasterDetailPage
    {
        public MainMasterDetailPage()
        {
            InitializeComponent();
            this.BindingContext = new MasterDetailPageViewModel(this.Navigation);
        }
    }
}