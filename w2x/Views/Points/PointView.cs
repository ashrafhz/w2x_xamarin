using System;
using Cognitive.Component;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Points
{
	public class PointView : ContentView
	{
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
							Configuration.GetSeperator("100,000",35),
							new StackLayout {
								Margin = new Thickness(0,20,0,0),
								HorizontalOptions = LayoutOptions.Center,
								Orientation = StackOrientation.Horizontal,
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

		void Transaction_Clicked(object sender, EventArgs e)
		{
			Navigation.PopToRootAsync();
		}
	}
}

