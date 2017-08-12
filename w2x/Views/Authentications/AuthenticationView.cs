using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using w2x.Component;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using w2x.Models.Configurations;
using w2x.Models.Logics;
using w2x.Views.Greeting;
using Xamarin.Forms;

namespace w2x.Views.Authentications
{
	public class AuthenticationView : ContentView
	{
		CustomEntry _ECUsername, _ECPassword;

		public AuthenticationView()
		{
			var ImageLogo = new Image { Aspect = Aspect.AspectFit };
			ImageLogo.Source = ImageSource.FromFile("w2xicon.png");
			ImageLogo.HeightRequest = 100;
			ImageLogo.WidthRequest = 100;

			CustomButton _AuthenticationBtn = new CustomButton();
			_AuthenticationBtn.Text = "Sign In";
			_AuthenticationBtn.WidthRequest = 120;
			_AuthenticationBtn.Clicked += Authentication_Clicked;

			CustomButton _CancelBtn = new CustomButton();
			_CancelBtn.Text = "Cancel";
			_CancelBtn.WidthRequest = 120;
			_CancelBtn.Clicked += Cancel_Clicked;

			_ECUsername = new CustomEntry()
			{
				Placeholder = "Username",
				WidthRequest = 300
			};

			_ECPassword = new CustomEntry()
			{
				Placeholder = "Password",
				WidthRequest = 300,
				IsPassword = true
			};

			Content = new StackLayout
			{
				Children =
				{
					new StackLayout{
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand,
						Orientation = StackOrientation.Vertical,
						Children = {
							Configuration.GetBigLogo(),
							Configuration.GetSeperator("w2x",50),
							_ECUsername,
							_ECPassword,
							new StackLayout {
								Margin = new Thickness(0,20,0,0),
								HorizontalOptions = LayoutOptions.Center,
								Orientation = StackOrientation.Horizontal,
								Children = {
									_AuthenticationBtn
									//_CancelBtn
								}
							}
						}
					}
				}
			};
		}

		private async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void Authentication_Clicked(object sender, EventArgs e)
		{

			var config = new ProgressDialogConfig
			{
				Title = "Authorize..",
				AutoShow = true,
				MaskType = MaskType.Black
			};
			using (var dialog = UserDialogs.Instance.Progress(config))
			{
				if (!string.IsNullOrEmpty(_ECUsername.Text) && !string.IsNullOrEmpty(_ECPassword.Text))
				{
					List<Users> _Result = Users.SignIn(_ECUsername.Text, _ECPassword.Text);
					if (_Result.Count > 0)
					{
						//Navigation.PushAsync(new GreetingPage(_Result[0]), true);
						VisionAuthorization(_Result[0]);
					}
					else
					{
						UserDialogs.Instance.Alert(
							title: "Authentication Failed",
							message: "Your combination username and password not match.",
							okText: "OK"
						);
					}
				}
				else
				{
					UserDialogs.Instance.Alert(
							title: "Authentication",
							message: "Please fill in the form",
							okText: "OK"
						);
				}

				//await Navigation.PushAsync(new GreetingPage(_Result), true);
			}
		}


		private async void VisionAuthorization(Users _Result )
		{
			if (CrossConnectivity.Current.IsConnected)
			{
				MediaFile photo;

				await CrossMedia.Current.Initialize();

				// Take or select a photo using the Media Plugin for Xamarin and Windows
				if (CrossMedia.Current.IsCameraAvailable)
				{
					photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
					{
						Directory = "w2x",
						Name = "photo.jpg"
					});
				}
				else
				{
					photo = await CrossMedia.Current.PickPhotoAsync();
				}
				//UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
				var config = new ProgressDialogConfig
				{
					Title = "Authorization...",
					AutoShow = true
				};
				using (var dialog = UserDialogs.Instance.Progress(config))
				{
					Navigation.PushAsync(new GreetingPage(_Result), true);
				}
			}
			else
			{
				UserDialogs.Instance.Alert(
					title: "Network Unreacable",
					message: "There are no internet connectivity",
					okText: "OK"
				);
			}
		}
	}
}
