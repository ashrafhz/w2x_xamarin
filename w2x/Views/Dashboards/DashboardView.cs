using System;
using Cognitive.Component;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace w2x.Views.Dashboards
{
	public class DashboardView : ContentView
	{
		public DashboardView()
		{
			CustomButton _DustbinBtn = new CustomButton();
			_DustbinBtn.Text = "Dustbin";
			_DustbinBtn.WidthRequest = 110;
			_DustbinBtn.Clicked += Dustbin_Clicked;

			CustomButton _CollectionBtn = new CustomButton();
			_CollectionBtn.Text = "Collection";
			_CollectionBtn.WidthRequest = 110;
			_CollectionBtn.Clicked += Collection_Clicked;

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
									_DustbinBtn,
									_CollectionBtn
								}
							}
						}
					}
				}
			};
		}

		private async void Dustbin_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new DustbinPage(), true);
		}

		private async void Collection_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CollectionHistoryPage(), true);
		}
	}
}

