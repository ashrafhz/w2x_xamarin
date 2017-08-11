using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Dashboards
{
	public class DashboardPage : ContentPage
	{
		public DashboardPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "Dashboard";
			BackgroundColor = Configuration.ThemeColor;
			Content = new DashboardView();
		}
	}
}

