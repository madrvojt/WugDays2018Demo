using System.ComponentModel;
using Android.Content;
using WugDays2018Demo.Android.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Base = Android;

[assembly: ExportRenderer(typeof(Entry), typeof(ColorEntryRenderer))]

namespace WugDays2018Demo.Android.Renderers
{

    public class ColorEntryRenderer : EntryRenderer
    {
        public ColorEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.SetTextColor(Base.Graphics.Color.Red);
        }

    }
}