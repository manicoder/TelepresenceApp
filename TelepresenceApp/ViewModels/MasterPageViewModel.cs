using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TelepresenceApp.Utils;
using TelepresenceApp.Views;
using Xamarin.Forms;

namespace TelepresenceApp.ViewModels
{
    public class MasterDetailPageViewModel : BaseViewModel
    {
        public MasterDetailPageViewModel(INavigation navigation) : base(navigation)
        {


            LogoutCommand = new Command(() =>
            {
                App.Current.MainPage = new LoginPage();
            });
            string[] tmpString = { }; //{ "A", "B", "C", "D" };


            switch (AppUtility.CurrentAppType)
            {
                case CurrentAppTypeEnum.Collaborator:
                    tmpString = new string[] { "Robot", "Call History","Collaborator Settings", "Logout" };
                    break;
                case CurrentAppTypeEnum.Partner:
                    tmpString = new string[] { "Robot","Host", "Call History","Partner Settings", "Logout" };
                    break;
                case CurrentAppTypeEnum.Host:
                    tmpString = new string[] { "Robot", "Host", "Call History", "Logout" };
                    break;
                case CurrentAppTypeEnum.Bot:
                    tmpString = new string[] { "Connect bot", "Call History", "Logout" };
                    break;
                default:
                    break;
            }

            Items = new System.Collections.ObjectModel.ObservableCollection<string>(tmpString);

            if (AppUtility.CurrentAppType.ToString() == "Collaborator")
            {
                this.CurrentAppType = AppUtility.CurrentAppType.ToString();
            }
            else
            {
                this.CurrentAppType = "Collaborator " + AppUtility.CurrentAppType.ToString();
            }
            this.MyUserId = AppUtility.MyUserId;
        }
        private string mCurrentAppType;
        public string CurrentAppType
        {
            get { return mCurrentAppType; }
            set
            {
                mCurrentAppType = value;
                RaisePropertyChanged();
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<string> mItems;
        public System.Collections.ObjectModel.ObservableCollection<string> Items
        {
            get { return mItems; }
            set
            {
                mItems = value;
                RaisePropertyChanged();
            }
        }
        public ICommand LogoutCommand { get; set; }
    }
}
