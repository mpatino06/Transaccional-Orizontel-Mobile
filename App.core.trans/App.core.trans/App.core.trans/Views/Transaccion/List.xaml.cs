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
		public string _scodigo { get; set; }
		public RegistrosViewModel viewModel;
		public List ()
		{
			InitializeComponent ();
			//BindingContext = new RegistrosViewModel("ADMIN");

			viewModel = new RegistrosViewModel();
			MessagingCenter.Subscribe<MainPage, string>(this, "H2", (sender, arg) =>
			{
				char[] charSplit = { '.' };
				string[] splitUser = arg.Split(charSplit);

				viewModel.CodigoUsuario = splitUser[0].ToString();

				//viewModel.CodigoUsuario = arg.ToUpper();
				viewModel.LoadRegistros();
				//Application.Current.MainPage.DisplayAlert("SAC - Pelileo", arg, "OK");
			});

			
			BindingContext = viewModel; // new TransaccionViewModel();

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