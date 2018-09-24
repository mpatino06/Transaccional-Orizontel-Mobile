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

		private async void EnterButton_OnClicked(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(EntUser.Text) || string.IsNullOrEmpty(EntPassword.Text))
				{
					Lblmsg.Text = "Debe ingresar nombre de usuario y Password";
				}
				else
				{

					//var _user = EntUser.Text.Trim();
					//var _pass = EntPassword.Text.Trim();

					//var result = await services.GetProviderName(_user, _pass);

					//if (result == null)
					//	Lblmsg.Text = "Ha ingresado un Usuario o Password icorrecto";
					//else
					//{
					//await Navigation.PushAsync(new MainMenu(_user));
					//}
					await Navigation.PushAsync(new NavigationPage(new MainPage()));

					//await Navigation.PushAsync(new NavigationPage(new MainPage2()));
					//await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync((Page)new MainPage());
				}
			}
			catch (Exception ex)
			{
				Lblmsg.Text = "Error: " + ex.Message.ToString();
			}
		}
	}
}