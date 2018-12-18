using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
//using App.core.trans.Interfaces;

namespace App.core.trans.Droid
{
	public class CloseApplication : ICloseApp
	{

		public void closeApplication()
		{
			var activity = (Activity)Forms.Context;
			activity.FinishAffinity();
		}
	}
}