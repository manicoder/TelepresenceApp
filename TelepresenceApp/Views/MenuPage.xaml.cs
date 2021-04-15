using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TelepresenceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            this.listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var item = e.SelectedItem as MasterDetailPageMasterMenuItem;
            //if (item == null)
            //    return;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Detail = new NavigationPage(page);
            //IsPresented = false;

            //MasterPage.ListView.SelectedItem = null;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if ((e.Item as String) == "Logout")
            {
                (this.BindingContext as ViewModels.MasterDetailPageViewModel).LogoutCommand.Execute(null);
            }
        }
    }
}