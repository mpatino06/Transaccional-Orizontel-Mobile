using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Models;
using App.core.trans.Views;
using App.core.trans.Views.Count;
using App.core.trans.Views.Transaccion;
//using App.core.trans.Views.Transaccion;
using Xamarin.Forms;

namespace App.core.trans
{
	public partial class MainPage : MasterDetailPage
	{
		public List<MasterPageItem> menuList { get; set; }

		public MainPage()
		{
			InitializeComponent();
			menuList = new List<MasterPageItem>();
			LoadMenu();
		}

		public void LoadMenu()
		{
			menuList.Add(new MasterPageItem
			{
				Title = "Transacciones",
				Icon = "operacion.png",
				TargetType = typeof(Trans1)
			});
			menuList.Add(new MasterPageItem
			{
				Title = "Ver registros",
				Icon = "lista.png",
				TargetType = typeof(PlanList)
			});
			menuList.Add(new MasterPageItem
			{
				Title = "Salir",
				Icon = "salir.png",
				TargetType = typeof(PlanList)
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
		}


	}
}

