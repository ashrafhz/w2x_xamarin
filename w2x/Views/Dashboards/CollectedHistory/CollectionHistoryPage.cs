﻿using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x
{
	public class CollectionHistoryPage : ContentPage
	{
		public CollectionHistoryPage()
		{
			NavigationPage.SetHasNavigationBar(this, true);
			Title = "Pickup";
			BackgroundColor = Configuration.ThemeColor;
			Content = new CollectionHistoryView();
		}
	}
}

