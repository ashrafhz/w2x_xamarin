using System;

using Xamarin.Forms;

namespace w2x.Views.Dashboards.Dustbin
{
	public class AnalyticView : ContentView
	{
		public AnalyticView()
		{
			WebView _WV = new WebView();
			_WV.VerticalOptions = LayoutOptions.FillAndExpand;
			_WV.HorizontalOptions = LayoutOptions.FillAndExpand;
			_WV.Source = "https://thingspeak.com/channels/315881/charts/1?bgcolor=%23ffffff&color=%23d62020&dynamic=true&results=60&type=line&update=15";
			Content = _WV;
		}
	}
}

