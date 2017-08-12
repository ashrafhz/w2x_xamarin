using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Dashboards.Dustbin
{
	public class AnalyticPage : ContentPage
	{
		public AnalyticPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "Dustbin Location";
			BackgroundColor = Configuration.ThemeColor;
			Content = new AnalyticView();
		}
	}
}

