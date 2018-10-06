using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Bluetooth;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.core.trans;
using Android.App;

namespace App.core.trans.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuDetail : ContentPage
	{
		public MainMenuDetail ()
		{
			InitializeComponent ();

			//var myIntent = new Intent((ParentActivity)Activity, typeof(PrintActivity));
			//StartActivity(myIntent);

		}

	    void TestPrint()
		{

			
			//BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
			//if (adapter == null)
			//	throw new Exception("No Bluetooth adapter found.");

			//if (!adapter.IsEnabled)
			//	throw new Exception("Bluetooth adapter is not enabled.");

			//String dataToPrint = "$big$This is a printer test$intro$posprinterdriver.com$intro$$intro$$cut$$intro$";

			//Intent intentPrint = new Intent();

			//intentPrint.SetAction(Intent.ActionSend);
			//intentPrint.PutExtra(Intent.ExtraText, dataToPrint);
			//intentPrint.SetType("text/plain");

			//Context.StartActivity(intentPrint);


		}
		



	}
}