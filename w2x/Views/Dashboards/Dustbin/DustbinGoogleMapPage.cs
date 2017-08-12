using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Dashboards.Dustbin
{
	public class DustbinGoogleMapPage : ContentPage
	{
		public DustbinGoogleMapPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "Dustbin Location";
			BackgroundColor = Configuration.ThemeColor;
			Content = new DustbinGoogleMapView();
		}
	}
}

