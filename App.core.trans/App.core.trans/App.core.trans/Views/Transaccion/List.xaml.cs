using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using App.core.trans.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.core.trans.Views.Transaccion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class List : ContentPage
	{
		public List ()
		{
			InitializeComponent ();
			BindingContext = new RegistrosViewModel("ADMIN");

			//var activity = (Activity)App.Current;

			//String dataToPrint = "$big$This is a printer test$intro$posprinterdriver.com$intro$$intro$$cut$$intro$";
			//Intent intentPrint = new Intent();
			//intentPrint.SetAction(Intent.ActionSend);
			//intentPrint.PutExtra(Intent.ExtraText, dataToPrint);
			//intentPrint.SetType("text/plain");
			//Content.StartActivity(intentPrint);

		}
	}
}