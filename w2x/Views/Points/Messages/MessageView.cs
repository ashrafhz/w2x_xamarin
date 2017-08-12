using System;
using w2x.Component;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Points.Messaged
{
	public class MessageView : ContentView
	{
		public MessageView(bool _argSuccess)
		{
			CustomButton _CloseBtn = new CustomButton();
			_CloseBtn.Text = "Close";
			_CloseBtn.WidthRequest = 120;
			_CloseBtn.Clicked += Close_Clicked;

			if (!_argSuccess)
			{
				_CloseBtn.BackgroundColor = Configuration.FailedColor;
			}

			String _MessageHeader = "Failed",
				   _MessageDetail = "Transaction Failed. Thank you";
			StackLayout _MessageIcon = Configuration.GetErrorIcon();

			if (_argSuccess)
			{
				_MessageHeader = "Success";
				_MessageDetail = "Your redeem product is successfull";
				_MessageIcon = Configuration.GetSuccessIcon();
			}

			Content = new StackLayout
			{
				Children =
				{
					new StackLayout{
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Orientation = StackOrientation.Vertical,
						Padding = new Thickness(50,0),
						Children = {
							_MessageIcon,
							Configuration.GetSeperator(_MessageHeader,35),
							Configuration.GetSeperator(_MessageDetail,15),
							new StackLayout {
								Margin = new Thickness(0,20,0,0),
								HorizontalOptions = LayoutOptions.Center,
								Orientation = StackOrientation.Horizontal,
								Children = {
									_CloseBtn
								}
							}
						}
					}
				}
			};
		}

		private async void Close_Clicked(object sender, EventArgs e)
		{
			//await Navigation.PushAsync(new PointPage(), true);
			await Navigation.PopAsync();;
		}
	}
}

