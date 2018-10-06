using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.core.trans.Views.Transaccion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Trans3 : ContentPage
	{
		public Trans3 ()
		{
			InitializeComponent ();

			ListViewDeposito.SelectedItem = (object)null;
		}
	}
}