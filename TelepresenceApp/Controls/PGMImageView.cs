using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GCoreApp.Controls
{
    public class PGMImageView : View
    {
        public event EventHandler OnImageLoaded;

        public int MyProperty { get; set; }

        
    }
}