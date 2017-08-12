using System;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Points.Messaged
{
	public class MessagePage : ContentPage
	{
		public MessagePage(bool _Success)
		{
			NavigationPage.SetHasNavigationBar(this, false);
			if (_Success)
			{
				BackgroundColor = Configuration.ThemeColor;
			}
			else
			{
				BackgroundColor = Configuration.FailedColor;
			}
			Content = new MessageView(_Success);
		}
	}
}

