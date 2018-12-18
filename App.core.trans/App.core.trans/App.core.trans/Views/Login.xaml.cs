using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Helper;
using App.core.trans.Models;
using App.core.trans.Services;
using App.core.trans.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.core.trans.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		//Security security;
		UsuarioServices services;
		//private TransaccionViewModel vm;
		public string _susuario { get; set; }
		public Login ()
		{
			InitializeComponent ();
			
		}

		private async void EnterButton_OnClicked(object sender, EventArgs e)
		{
			try
			{
				DateTime x = Convert.ToDateTime(DateTime.Now.ToShortDateString());

				var y = DateTime.Now.Date;

				///security = new Security();
				services = new UsuarioServices();
				if (string.IsNullOrEmpty(EntUser.Text) || string.IsNullOrEmpty(EntPassword.Text))
				{
					await Application.Current.MainPage.DisplayAlert("SAC", "Debe ingresar nombre de usuario y Password", "OK");
				}
				else
				{

					var result = await services.GetUsuario(EntUser.Text, EntPassword.Text.Trim());
					if (result.usuarioComplemento != null)
					{
						if (result.AccesoUsuario)
						{

							//_susuario = EntUser.Text;
							_susuario = result.usuarioComplemento.Codigousuario;
							//vm.CodigoUsuarioVM = EntUser.Text.Trim().ToUpper();
							//MessagingCenter.Send<Login>(this, result.usuarioComplemento.Codigousuario);

							App.Current.MainPage = new MainPage(_susuario);
						}
						else {
							await Application.Current.MainPage.DisplayAlert("SAC", "Horario no permitido para el usuario", "OK");
						}

					}						
					else
						await Application.Current.MainPage.DisplayAlert("SAC", "Los datos ingresados no son correctos", "OK");

				}				
			}
			catch (Exception ex)
			{
				Lblmsg.Text = "Error: " + ex.Message.ToString();
			}
		}
	}
}