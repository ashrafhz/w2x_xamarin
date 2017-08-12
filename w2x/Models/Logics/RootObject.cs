using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace w2x.Models.Logics
{
	public class Channel
	{
		public int id { get; set; }
		public string name { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
		public string field1 { get; set; }
		public string created_at { get; set; }
		public string updated_at { get; set; }
		public int last_entry_id { get; set; }
	}

	public class Feed
	{
		public string created_at { get; set; }
		public int entry_id { get; set; }
		public string field1 { get; set; }
	}

	public class RootObject
	{
		public Channel channel { get; set; }
		public List<Feed> feeds { get; set; }
	}
}

