using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Helper;
using App.core.trans.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.core.trans.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		//Security security;
		UsuarioServices services;
		public Login ()
		{
			InitializeComponent ();
		}

		private async void EnterButton_OnClicked(object sender, EventArgs e)
		{
			try
			{
				///security = new Security();
				services = new UsuarioServices();
				if (string.IsNullOrEmpty(EntUser.Text) || string.IsNullOrEmpty(EntPassword.Text))
				{
					await Application.Current.MainPage.DisplayAlert("SAC", "Debe ingresar nombre de usuario y Password", "OK");
					//Lblmsg.Text = "Debe ingresar nombre de usuario y Password";
				}
				else
				{

					//var result = await services.GetUsuario(EntUser.Text, EntPassword.Text.Trim());
					//if(result.usuarioComplemento != null)
					//	App.Current.MainPage = new MainPage();
					//else
					//	await Application.Current.MainPage.DisplayAlert("SAC", "Los datos ingresados no son correctos", "OK");

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