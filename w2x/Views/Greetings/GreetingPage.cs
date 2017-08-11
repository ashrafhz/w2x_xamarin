using System;
using w2x.Models.Configurations;
using w2x.Models.Logics;
using Xamarin.Forms;

namespace w2x.Views.Greeting
{
	public class GreetingPage : ContentPage
	{
		public GreetingPage(Users _argUser)
		{
			NavigationPage.SetHasNavigationBar(this, false);
			Title = "Greeting";
			BackgroundColor = Configuration.ThemeColor;
			Content = new GreetingView(_argUser);
		}
	}
}

