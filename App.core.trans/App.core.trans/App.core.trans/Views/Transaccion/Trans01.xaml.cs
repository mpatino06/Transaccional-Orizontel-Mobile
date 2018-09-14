using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.core.trans.Views.Transaccion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trans01 : ContentPage
	{
		public Trans01 ()
		{
			InitializeComponent ();
			BindingContext = new TransaccionViewModel();
		}
	}
}