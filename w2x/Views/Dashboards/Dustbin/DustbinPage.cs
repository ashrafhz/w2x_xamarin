using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x
{
	public class DustbinPage : ContentPage
	{
		public DustbinPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "List Of Dustbin";
			BackgroundColor = Configuration.ThemeColor;
			Content = new DustbinView();
		}
	}
}

