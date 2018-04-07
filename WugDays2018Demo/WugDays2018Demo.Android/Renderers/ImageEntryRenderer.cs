using Android.Content;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Android.Support.V4.Content.Res;
using Android.Views.InputMethods;
using WugDays2018Demo.Interface;
using Xamarin.Forms.Platform.Android;
using WugDays2018Demo.Android;
using WugDays2018Demo.Controls;
using Android.Graphics;
using Android.Util;
using Android.OS;
using Base = Android;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ImageEntry), typeof(ImageEntryRenderer))]
namespace WugDays2018Demo.Android
{

    public class ImageEntryRenderer : EntryRenderer
	{
        public ImageEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				var drawableRight = ResourcesCompat.GetDrawable(Resources, Resource.Drawable.ic_mic_black_24dp, null);

                var color = new Base.Graphics.Color(255, 255, 255);
                Control.SetBackgroundColor(color);
                Control.SetCompoundDrawablesWithIntrinsicBounds(null, null, ResourcesCompat.GetDrawable(Resources, Resource.Drawable.ic_mic_black_24dp, null), null);
				Control.Gravity = GravityFlags.CenterVertical;
				Control.SetPadding(30, 20, 30, 20);
				Control.Touch += Control_Touch;
			}
		}


        private void Control_Touch(object sender, TouchEventArgs e)
		{

			Rect bounds;
			int actionX, actionY;

			if (e.Event.Action == MotionEventActions.Down)
			{
				actionX = (int)e.Event.GetX();
				actionY = (int)e.Event.GetY();

				var drawableRight = ((EditText)sender).GetCompoundDrawables()[2];


				// this works for left since container shares 0,0 origin with bounds
				if (drawableRight != null)
				{
					bounds = null;
					bounds = drawableRight.Bounds;

					int x, y;
					int extraTapArea = 13;

					x = (int)(actionX + extraTapArea);
					y = (int)(actionY - extraTapArea);

                    x = ((Base.Views.View)sender).Width - x;

                    if (x <= 0)
					{
						x += extraTapArea;
					}

					if (y <= 0)
						y = actionY;

					if (bounds.Contains(x, y))
					{
						var element = (IEditTextController)Element;
						element.ItemTapped();


					}
					else
					{

						((EditText)sender).Focusable = true;
						((EditText)sender).FocusableInTouchMode = true;
						((EditText)sender).RequestFocusFromTouch();
						((EditText)sender).RequestFocus();
						InputMethodManager imm = (InputMethodManager)Context.GetSystemService(Context.InputMethodService);
						imm.ShowSoftInput(((EditText)sender), ShowFlags.Forced);
					}						

				}

			}


		}
	}
}