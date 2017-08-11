using System;
using Cognitive.Component;
using w2x.Models.Configurations;
using w2x.Models.Logics;
using w2x.Views.Dashboards;
using w2x.Views.Points;
using Xamarin.Forms;

namespace w2x.Views.Greeting
{
	public class GreetingView : ContentView
	{
		String _varGroup = string.Empty;
		public GreetingView(Users _argUser)
		{
			CustomButton _GoToMainMenuBtn = new CustomButton();
			_varGroup = _argUser.Group[0].Name;
			if (_varGroup == "Community")
			{
				_GoToMainMenuBtn.Text = "Point";
			}
			else
			{
				_GoToMainMenuBtn.Text = "Dashboard";
			}
			_GoToMainMenuBtn.WidthRequest = 110;
			_GoToMainMenuBtn.Clicked += GoToMainMenu_Clicked;

			CustomButton _LogoutBtn = new CustomButton();
			_LogoutBtn.Text = "Sign Out";
			_LogoutBtn.WidthRequest = 110;
			_LogoutBtn.Clicked += Logout_Clicked;

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
							Configuration.GetProfileIcon(),
							Configuration.GetSeperator("Greeting Hii!!",35),
							Configuration.GetSeperator(_argUser.FullName,15),
							//Configuration.GetSeperator(_Result.Results.CIS_No,15),
							new StackLayout {
								Margin = new Thickness(0,20,0,0),
								HorizontalOptions = LayoutOptions.Center,
								Orientation = StackOrientation.Horizontal,
								Children = {
									_GoToMainMenuBtn,
									_LogoutBtn
								}
							}
						}
					}
				}
			};
		}

		private async void GoToMainMenu_Clicked(object sender, EventArgs e)
		{
			if (_varGroup == "Community")
			{
				await Navigation.PushAsync(new PointPage(), true);
			}
			else 
			{ 
				await Navigation.PushAsync(new DashboardPage(), true);
			}
		}

		void Logout_Clicked(object sender, EventArgs e)
		{
			Navigation.PopToRootAsync();
		}
	}
}
