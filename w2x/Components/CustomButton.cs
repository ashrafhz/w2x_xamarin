using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Component
{
	public class CustomButton : Button
	{
		public CustomButton()
		{
			this.WidthRequest = 100;
			this.HeightRequest = 37;
			this.BorderRadius = 18;
			this.BorderWidth = 2;
			#if __IOS__
			this.BorderColor = Configuration.TextColor;
			#endif
			this.TextColor = Configuration.TextColor;
			#if __IOS__
			this.BackgroundColor = Configuration.ThemeColor;
			#endif
		}
	}
}
