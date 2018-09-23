using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App.core.trans.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(App.core.trans.MyEntry), typeof(MyEntryRenderer))]
namespace App.core.trans.Droid
{
	public class MyEntryRenderer : EntryRenderer
	{
		public MyEntryRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				//Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);

				var gradientDrawable = new GradientDrawable();
				gradientDrawable.SetCornerRadius(40f);
				gradientDrawable.SetStroke(5, Android.Graphics.Color.Blue);
				gradientDrawable.SetColor(Android.Graphics.Color.LightGray);
				Control.SetBackground(gradientDrawable);

				Control.SetPadding(10, Control.PaddingTop, Control.PaddingRight,
					Control.PaddingBottom);


			}
		}

	}
}