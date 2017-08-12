using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Component
{
	public class CustomEntry : Entry
	{
		public CustomEntry()
		{
			this.HeightRequest = 37;
			this.TextColor = Configuration.ThemeColor;
			this.BackgroundColor = Configuration.TextColor;
			this.HorizontalTextAlignment = TextAlignment.Center;
			this.WidthRequest = 300;
		}
	}
}
