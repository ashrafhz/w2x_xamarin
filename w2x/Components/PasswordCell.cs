using w2x.Models.Configurations;
using Xamarin.Forms;

namespace Cognitive.Component
{
	internal class PasswordCell : ViewCell
	{
		private Label _label { get; set; }

		private Xamarin.Forms.Entry _control { get; set; }

		private Grid _base;

		internal string Label
		{
			get
			{
				return _label.Text;
			}
			set
			{
				_label.Text = value;
			}
		}

		internal Xamarin.Forms.Entry Control
		{
			set
			{
				//Remove picker if it exists
				if (_control != null)
				{
					_base.Children.Remove(_control);
				}

				//Set its value
				_control = value;
				//Add to layout
				_base.Children.Add(_control, 1, 0);

			}
		}

		internal PasswordCell()
		{
			_label = new Label()
			{
				VerticalOptions = LayoutOptions.Center,
				TextColor = Configuration.ThemeColor
			};

			_base = new Grid()
			{
				ColumnDefinitions = new ColumnDefinitionCollection() {
				new ColumnDefinition () { Width = new GridLength (90, GridUnitType.Absolute) },
				new ColumnDefinition () { Width = new GridLength (7, GridUnitType.Star) }
			},
				Padding = new Thickness(15,2,15,2)
			};

			_base.Children.Add(_label, 0, 0);

			this.View = _base;
		}
	}
}
