using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Authentications
{
	public class AuthenticationPage : ContentPage
	{
		public AuthenticationPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			Title = "Authentication";
			BackgroundColor = Configuration.ThemeColor;
			Content = new AuthenticationView();
		}
	}
}

