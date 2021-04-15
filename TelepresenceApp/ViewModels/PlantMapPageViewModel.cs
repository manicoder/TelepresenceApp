
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelepresenceApp.ViewModels;
using Xamarin.Forms;

namespace GCoreApp.ViewModels
{
    public class PlantMapPageViewModel : BaseViewModel
    {
        public event EventHandler OnImageLoaded;

        public PlantMapPageViewModel(INavigation navigationService) : base(navigationService)
        {


        }

    }
}
