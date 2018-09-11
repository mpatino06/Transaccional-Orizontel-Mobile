using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.core.trans.Models;
using App.core.trans.Views;
using App.core.trans.Views.Count;
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
				Title = "Plan de Conteo",
				Icon = "ic1.png",
				TargetType = typeof(PlanList)
			});
			menuList.Add(new MasterPageItem
			{
				Title = "Recepcion",
				Icon = "ic1.png",
				TargetType = typeof(PlanList)
			});
			menuList.Add(new MasterPageItem
			{
				Title = "Tansferencia entre Bodegas",
				Icon = "ic1.png",
				TargetType = typeof(PlanList)
			});


			navigationDrawerList.ItemsSource = (IEnumerable)this.menuList;
			Detail = (Page)new NavigationPage((Page)Activator.CreateInstance(typeof(MainMenuDetail)))
			{
				BarBackgroundColor = Color.FromHex("#082adb"),
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
				BarBackgroundColor = Color.FromHex("#082adb"),
				BarTextColor = Color.White
			};
			navigationDrawerList.SelectedItem = (object)null;
			IsPresented = false;
		}


	}
}

