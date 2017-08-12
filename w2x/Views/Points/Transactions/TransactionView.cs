using System;
using System.Collections.Generic;
using Acr.UserDialogs;
using w2x.Component;
using w2x.Models.Configurations;
using w2x.Models.Logics;
using w2x.Views.Greeting;
using w2x.Views.Points;
using w2x.Views.Points.Messaged;
using Xamarin.Forms;

namespace w2x
{
	public class TransactionView : ContentView
	{
		static INavigation _Navigation;
		public TransactionView()
		{
			_Navigation = Navigation;
			CustomButton _CancelBtn = new CustomButton();
			_CancelBtn.Text = "Back";
			_CancelBtn.WidthRequest = 120;
			_CancelBtn.Clicked += Cancel_Clicked;

			Content = new StackLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Orientation = StackOrientation.Vertical,
				Children =
				{
					//Configuration.GetSeperator("LIST OF DONATION",15),
					new ScrollView()
{
	BackgroundColor = Xamarin.Forms.Color.FromHex("EBEBEB"),
						HeightRequest = 870,//495,
						Content = ListTemplate(Points.GetPointHistory(GreetingView._UserId))

					},
					new StackLayout {
						Margin = new Thickness(0,15),
						HorizontalOptions = LayoutOptions.Center,
						Orientation = StackOrientation.Horizontal,
						BackgroundColor = Configuration.ThemeColor,
						Children = {
							//_RegisterBtn,
							_CancelBtn
						}
					}
				}
			};
		}

		static StackLayout ListTemplate(List<Points> _Point)
		{
			StackLayout _Value = new StackLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, 5, 0, 0)
			};

			foreach (Points _Obj in _Point)
			{
				var grid = new Grid();
				grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
				grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
				grid.Children.Add(new StackLayout
				{
					Children = {	
						new Label{
							Text = (_Obj.Product != null ? _Obj.Product.Name : _Obj.Description + " "),
							FontSize = 15
						},
						new Label{
							Text = (_Obj.Product != null ? _Obj.Product.Merchandise + " " + _Obj.Created.ToString() : _Obj.Weight + " kg " +  _Obj.Created.ToString() ),
							FontSize = 13
						}
					}
				}, 0, 0);

				String _ListColor = "ListGreen.png";

				String _PointVal = "0", _ColorVal = "ef677d";
				if (_Obj.Credit == 0)
				{
					_PointVal = "+" + _Obj.Debit.ToString();
					_ColorVal = "8dc63f";
				}
				if (_Obj.Debit == 0)
				{
					_PointVal = "-" + _Obj.Credit.ToString();
					_ColorVal = "ef677d";
				}

				CustomButton _DonateBtn = new CustomButton();
				_DonateBtn.Text = _PointVal + " pts";
				_DonateBtn.WidthRequest = 120;
				_DonateBtn.Margin = new Thickness(0, 5, 0, 0);
				_DonateBtn.BackgroundColor = Xamarin.Forms.Color.FromHex(_ColorVal);

				grid.Children.Add(new StackLayout
				{
					//Margin = 5,
					//BackgroundColor = _ColorStatus,
					VerticalOptions = LayoutOptions.FillAndExpand,
					HorizontalOptions = LayoutOptions.FillAndExpand,
					Children = {
						_DonateBtn
					}
				}, 1, 0);

				StackLayout _SL = new StackLayout()
				{
					ClassId = "test",
					HeightRequest = 60,
					//BackgroundColor = Color.White,
					Orientation = StackOrientation.Horizontal,
					//Padding = 5,
				};

				RelativeLayout layout = new RelativeLayout();
				layout.HeightRequest = 60;
				layout.Children.Add(new Image()
				{
					Source = ImageSource.FromFile(_ListColor)
				},
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent((parent) => { return parent.Width; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));

				layout.Children.Add(grid,
				Constraint.Constant(25),
				Constraint.Constant(7),
				Constraint.RelativeToParent((parent) => { return parent.Width - 35; }),
				Constraint.RelativeToParent((parent) => { return parent.Height; }));

				_SL.Children.Add(layout);

				_Value.Children.Add(
					_SL
				);
			}

			return _Value;
		}


		private async void Cancel_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

	}
}

