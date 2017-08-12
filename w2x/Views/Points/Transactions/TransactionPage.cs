using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x
{
	public class TransactionPage : ContentPage
	{
		public TransactionPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "Transaction";
			BackgroundColor = Configuration.ThemeColor;
			Content = new TransactionView();
		}
	}
}

