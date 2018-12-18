using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Models;
using App.core.trans.ViewModels;
using App.core.trans.Views;
using App.core.trans.Views.Count;
using App.core.trans.Views.Transaccion;
using Xamarin.Forms;

namespace App.core.trans
{
	public partial class MainPage: MasterDetailPage
	{
		public string s_codigo { get; set; }
		public List<MasterPageItem> menuList { get; set; }

		public MainPage(string s_page)
		{
			InitializeComponent();
			menuList = new List<MasterPageItem>();
			s_codigo = s_page;
			LoadMenu();

			//Views.Login log = new Views.Login();
			//MessagingCenter.Send<MainPage, string>(this, "Hi", s_codigo);
		}

		public void LoadMenu()
		{
			var x = s_codigo;
			menuList.Add(new MasterPageItem
			{
				Title = "Transacciones",
				Icon = "operacion.png",
				TargetType = typeof(Trans1),
				Usuario = s_codigo
			});

			menuList.Add(new MasterPageItem
			{
				Title = "Ver registros",
				Icon = "lista.png",
				TargetType = typeof(List),
				Usuario = s_codigo
			});

			menuList.Add(new MasterPageItem
			{
				Title = "Salir",
				Icon = "salir.png",
				TargetType = typeof(PlanList),
				Usuario = s_codigo
			});

			navigationDrawerList.ItemsSource = (IEnumerable)this.menuList;
			Detail = (Page)new NavigationPage((Page)Activator.CreateInstance(typeof(MainMenuDetail)))
			{
				BarBackgroundColor = Color.FromHex("#092f5e"),
				BarTextColor = Color.White
			};
		}

		private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			try
			{
				MasterPageItem selectedItem = e.SelectedItem as MasterPageItem;
				if (selectedItem == null)
					return;
				Detail = (Page)new NavigationPage((Page)Activator.CreateInstance(selectedItem.TargetType))
				{
					BarBackgroundColor = Color.FromHex("#092f5e"),
					BarTextColor = Color.White
				};
				navigationDrawerList.SelectedItem = (object)null;
				IsPresented = false;

				if (selectedItem.Title == "Transacciones" || selectedItem.Title == null)
				{
					MessagingCenter.Send<MainPage, string>(this, "H1", s_codigo);
				}
				else if (selectedItem.Title == "Ver registros")
				{
					MessagingCenter.Send<MainPage, string>(this, "H2", s_codigo);
				}
				else if (selectedItem.Title == "Salir")
				{
					System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
				}
			}
			catch (Exception ex)
			{
				//MessagingCenter.Send<MainPage, string>(this, "H1", s_codigo);
				//throw;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//MessagingCenter.Subscribe<Views.Login, string>(this, "HelloMessage", (sender, a) => { s_codigo = a; });
		}
	}
}

