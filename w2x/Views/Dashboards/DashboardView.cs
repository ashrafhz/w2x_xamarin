using System;
using w2x.Component;
using w2x.Models.Configurations;
using w2x.Models.Logics;
using w2x.Views.Dashboards.Dustbin;
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
			_CollectionBtn.Text = "Pickup";
			_CollectionBtn.WidthRequest = 110;
			_CollectionBtn.Clicked += Collection_Clicked;

			CustomButton _AnalyticBtn = new CustomButton();
			_AnalyticBtn.Text = "Analytics";
			_AnalyticBtn.WidthRequest = 110;
			_AnalyticBtn.Clicked += Analytic_Clicked;

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
							Configuration.GetSeperator(Dustbins.IdentifyOverallKPI()+"%",80),
							new StackLayout {
								Margin = new Thickness(0,20,0,0),
								HorizontalOptions = LayoutOptions.Center,
								Orientation = StackOrientation.Vertical,
								Children = {
									_DustbinBtn,
									_CollectionBtn,
									_AnalyticBtn
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

		private async void Analytic_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AnalyticPage(), true);
		}
	}
}

