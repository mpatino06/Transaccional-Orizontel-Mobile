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
	
		public Trans1 ()
		{					
			InitializeComponent ();
			BindingContext = new TransaccionViewModel();
		}

	}
}