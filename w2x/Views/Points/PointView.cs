using System;
using w2x.Component;
using w2x.Models.Configurations;
using w2x.Views.Points.Redeems;
using Xamarin.Forms;

namespace w2x.Views.Points
{
	public class PointView : ContentView
	{
		public static float _GlobalPoint = 0;
		public static Label _GlobalPointLbl;
		public PointView()
		{
			CustomButton _RedeemBtn = new CustomButton();
			_RedeemBtn.Text = "Redeem";
			_RedeemBtn.WidthRequest = 110;
			_RedeemBtn.Clicked += Redeem_Clicked;

			CustomButton _TransactionBtn = new CustomButton();
			_TransactionBtn.Text = "Transaction";
			_TransactionBtn.WidthRequest = 110;
			_TransactionBtn.Clicked += Transaction_Clicked;

			_GlobalPointLbl = new Label
			{
				Margin = new Thickness(0, 10, 0, 0),
				Text = _GlobalPoint.ToString("#,##0"),
				FontSize = 70,
				//FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center,
				TextColor = Configuration.HightlightColor
			};

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
							_GlobalPointLbl,
							Configuration.GetSeperator("Points",20),
							new StackLayout {
								Margin = new Thickness(0,20,0,0),
								HorizontalOptions = LayoutOptions.Center,
								Orientation = StackOrientation.Vertical,
								Children = {
									_RedeemBtn,
									_TransactionBtn
								}
							}
						}
					}
				}
			};
		}

		private async void Redeem_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new RedeemPage(), true);
		}

		private async void Transaction_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TransactionPage(), true);
		}
	}
}

