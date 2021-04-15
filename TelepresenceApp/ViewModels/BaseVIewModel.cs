using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TelepresenceApp.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        protected BaseViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
        }

        private string mMyUserId;
        public string MyUserId
        {
            get { return mMyUserId; }
            set
            {
                mMyUserId = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
