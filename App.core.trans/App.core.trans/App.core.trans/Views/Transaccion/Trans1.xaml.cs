using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Models;
using App.core.trans.ViewModels;
using PSC.Xam.Controls.BindableRadioButton;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.core.trans.Views.Transaccion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trans1 : ContentPage
	{

		public TransaccionViewModel viewModel;
		public Trans1 ()
		{					
			InitializeComponent ();

			viewModel = new TransaccionViewModel();
			

			MessagingCenter.Subscribe<MainPage, string>(this, "H1", (sender, arg) =>
			{

				char[] charSplit = { '.' };
				string[] splitUser = arg.Split(charSplit);

				viewModel.CodigoUsuarioVM =  splitUser[0].ToString();
				viewModel.SecuencialOficinaVM = Convert.ToInt32(splitUser[1].ToString());
				//Application.Current.MainPage.DisplayAlert("SAC - Pelileo", arg, "OK");
			});
			BindingContext = viewModel; // new TransaccionViewModel();
		}

		//protected override void OnAppearing()
		//{
		//	base.OnAppearing();

		//	//var x = ((MasterDetailPage)Application.Current.MainPage);
		//	//var y = MasterDetailPage.GetMenu(x.Master).FirstOrDefault();

		//	//MessagingCenter.Subscribe<MainPage, string>(this, "Hi", (sender, arg) => {
		//	//	// do something whenever the "Hi" message is sent
		//	//	// using the 'arg' parameter which is a string

		//	//	Application.Current.MainPage.DisplayAlert("SAC - Pelileo", arg, "OK");
		//	//	//othermodel = arg;
		//	//});
		//}
	}
}