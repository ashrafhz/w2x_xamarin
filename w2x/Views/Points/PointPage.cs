using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Points
{
	public class PointPage : ContentPage
	{
		public PointPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "Greeting";
			BackgroundColor = Configuration.ThemeColor;
			Content = new PointView();
		}
	}
}

