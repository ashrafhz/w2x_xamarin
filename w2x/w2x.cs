using System;
using w2x.Models.Configurations;
using w2x.Views.Authentications;
using Xamarin.Forms;

namespace w2x
{
	public class App : Application
	{
		public App()
		{
			NavigationPage _NV = new NavigationPage(new AuthenticationPage());
			_NV.BarBackgroundColor = Configuration.ThemeColor;
			_NV.BarTextColor = Configuration.TextColor;
			_NV.BackgroundColor = Configuration.ThemeColor;
			MainPage = _NV;
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
