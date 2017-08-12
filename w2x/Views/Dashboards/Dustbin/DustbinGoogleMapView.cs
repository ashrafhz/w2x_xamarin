using System;

using Xamarin.Forms;

namespace w2x.Views.Dashboards.Dustbin
{
	public class DustbinGoogleMapView : ContentView
	{
		public DustbinGoogleMapView()
		{
			WebView _WV = new WebView();
			_WV.VerticalOptions = LayoutOptions.FillAndExpand;
			_WV.HorizontalOptions = LayoutOptions.FillAndExpand;
			_WV.Source = "https://thingspeak.com/channels/315881/maps/channel_show";
			Content = _WV;
		}
	}
}

