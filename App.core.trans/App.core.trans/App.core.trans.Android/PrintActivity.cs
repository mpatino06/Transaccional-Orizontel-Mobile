using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App.core.trans.Droid
{
	[Activity(Label = "PrintActivity")]
	public class PrintActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			String dataToPrint = "$big$This is a printer test$intro$posprinterdriver.com$intro$$intro$$cut$$intro$";

			Intent intentPrint = new Intent();

			intentPrint.SetAction(Intent.ActionSend);
			intentPrint.PutExtra(Intent.ExtraText, dataToPrint);
			intentPrint.SetType("text/plain");

			StartActivity(intentPrint);
		}
	}
}