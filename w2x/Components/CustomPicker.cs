using System;
using System.Collections.Generic;
using w2x.Models.Configurations;
using Xamarin.Forms;

namespace Cognitive.Component
{
	public class CustomPicker : Picker
	{
		private Dictionary<String, String> _source { get; set; }

		internal Dictionary<String, String> Source
		{
			set
			{
				foreach (string _Keys in value.Keys)
				{
					this.Items.Add(_Keys);
				}
			}
			get
			{
				return _source;
			}
		}

		public CustomPicker()
		{
			this.HeightRequest = 37;
			this.TextColor = Configuration.ThemeColor;
			this.BackgroundColor = Configuration.TextColor;
			this.WidthRequest = 300;

		}
	}
}
