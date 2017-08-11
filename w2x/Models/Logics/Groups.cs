using System;
namespace w2x
{
	public class Groups
	{
		public Guid GroupId { get; set; }
		public String Name { get; set; }
		public Groups() { }
		public Groups(Guid GroupId, String Name)
		{
			this.GroupId = GroupId;
			this.Name = Name;
		}
	}
}
