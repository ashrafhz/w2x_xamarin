using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using w2x.Models.Configurations;

namespace w2x.Models.Logics
{
	public class Products
	{
		public Guid ProductId { get; set; }
		public String Name { get; set; }
		public String Merchandise { get; set; }
		public float Point { get; set; }
		public Products() { }
		public Products(Guid ProductId, String Name, String Merchandise, float Point)
		{
			this.ProductId = ProductId;
			this.Name = Name;
			this.Merchandise = Merchandise;
			this.Point = Point;
		}

		public static List<Products> GetAllProducts()
		{
			List<Products> _Value = new List<Products>();

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "GetAllProducts";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Conn.Open();

				SqlDataReader _Reader = _Cmd.ExecuteReader();

				try
				{
					while (_Reader.Read())
					{
						_Value.Add(new Products(
							Guid.Parse(_Reader["ProductId"].ToString()),
							_Reader["Name"].ToString(),
							_Reader["Merchandise"].ToString(),
							float.Parse(_Reader["Point"].ToString())
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
