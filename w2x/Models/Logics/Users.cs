using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using w2x.Models.Configurations;

namespace w2x.Models.Logics
{
	public class Users
	{
		public Guid UserId { get; set; }
		public String Username { get; set; }
		public String Password { get; set; }
		public String FullName { get; set; }
		public float Point { get; set; }
		public float Percentage { get; set; }
		public List<Groups> Group { get; set;}

		public Users() { }
		public Users(Guid UserId, String Username, String Password, String FullName, float Point, float Percentage, List<Groups> Group)
		{
			this.UserId = UserId;
			this.Username = Username;
			this.Password = Password;
			this.FullName = FullName;
			this.Point = Point;
			this.Percentage = Percentage;
			this.Group = Group;
		}

		public static List<Users> SignIn(String _argUsername, String _argPassword)
		{
			List<Users> _Value = new List<Users>();

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "SignIn";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Cmd.Parameters.AddWithValue("@Username", _argUsername);
				_Cmd.Parameters.AddWithValue("@Password", _argPassword);

				_Conn.Open();

				SqlDataReader _Reader = _Cmd.ExecuteReader();

				try {
					while (_Reader.Read())
					{
						List<Groups> _Groups = new List<Groups>();
						_Groups.Add(new Groups(Guid.Parse(_Reader["GroupId"].ToString()), _Reader["GroupName"].ToString()));
						_Value.Add(new Users(
							Guid.Parse(_Reader["UserId"].ToString()),
							_Reader["Username"].ToString(),
							_Reader["Password"].ToString(),
							_Reader["FullName"].ToString(),
							float.Parse(_Reader["Point"].ToString()),
							float.Parse(_Reader["Percentage"].ToString()),
							_Groups
						));
					}
				}
				finally 
				{
					_Conn.Close();
				}

			}

			return _Value;
		}
	}
}
