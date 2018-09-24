using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.core.trans.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

		private void EnterButton_OnClicked(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(EntUser.Text) || string.IsNullOrEmpty(EntPassword.Text))
				{
					Lblmsg.Text = "Debe ingresar nombre de usuario y Password";
				}
				else
				{
					App.Current.MainPage = new MainPage();

				}
			}
			catch (Exception ex)
			{
				Lblmsg.Text = "Error: " + ex.Message.ToString();
			}
		}
	}
}