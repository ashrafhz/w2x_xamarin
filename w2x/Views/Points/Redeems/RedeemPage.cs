using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x
{
	public class RedeemPage : ContentPage
	{
		public RedeemPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "Redeem";
			BackgroundColor = Configuration.ThemeColor;
			Content = new RedeemView();
		}
	}
}

