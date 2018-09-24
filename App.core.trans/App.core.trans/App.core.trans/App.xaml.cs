using System;
using App.core.trans.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App.core.trans
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = (Page)new Login();


			//MainPage = new NavigationPage(new Login()); // new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
