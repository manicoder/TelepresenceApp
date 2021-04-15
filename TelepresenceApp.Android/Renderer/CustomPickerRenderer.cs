using System;
using Android.Content;
using Android.Graphics.Drawables;
using GCoreApp.Controls;
using GCoreApp.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace GCoreApp.Droid.Renderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            var picker = e.NewElement;
 
            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Android.Graphics.Color.LightGray);
                Control.SetBackgroundDrawable(gd);
            }
        }
        //protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        //{
        //    base.OnElementChanged(e);
        //    if (Control != null)
        //    {
        //        Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        //    }
        //}
    }
}
