using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using w2x.Models.Configurations;

namespace w2x.Models.Logics
{
	public class Points
	{
		public Guid PointId { get; set; }
		public float Debit { get; set; }
		public float Credit { get; set; }
		public DateTime Created { get; set; }
		public String Description { get; set;}
		public int Weight { get; set; }
		public Users User { get; set; }
		public Products Product { get; set; }
		public Points() { }
		public Points(Guid PointId, float Debit, float Credit, DateTime Created, Users User, Products Product)
		{
			this.PointId = PointId;
			this.Debit = Debit;
			this.Credit = Credit;
			this.Created = Created;
			this.User = User;
			this.Product = Product;
		}

		public Points(Points Point, Users User, Products Product)
		{
			this.PointId = Point.PointId;
      		this.Debit = Point.Debit;
      		this.Credit = Point.Credit;
      		this.Created = Point.Created;
			this.Description = Point.Description;
			this.Weight = Point.Weight;
			this.User = User;
			this.Product = Product;
		}

		public static async Task<float> RedeemPoint(Guid UserId, Guid ProductId)
		{
			float _Value = 0;

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "RedeemPoint";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Cmd.Parameters.AddWithValue("@UserId", UserId);
				_Cmd.Parameters.AddWithValue("@ProductId", ProductId);

				_Conn.Open();

				SqlDataReader _Reader = _Cmd.ExecuteReader();

				try
				{
					while (_Reader.Read())
					{
						_Value = float.Parse(_Reader["Point"].ToString());
					}
				}
				finally
				{
					_Conn.Close();
				}

			}

			return _Value;
		}

		public static List<Points> GetPointHistory(Guid UserId)
		{
			List<Points> _Value = new List<Points>();

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "GetPointTransaction";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Cmd.Parameters.AddWithValue("@UserId", UserId);

				_Conn.Open();

				SqlDataReader _Reader = _Cmd.ExecuteReader();

				try
				{
					while (_Reader.Read())
					{
						Products _Product = null;
						object _Check = _Reader["ProductId"];
						if (_Reader["ProductId"] != DBNull.Value)
						{
							_Product = new Products(
							Guid.Parse(_Reader["ProductId"].ToString()),
							_Reader["Name"].ToString(),
							_Reader["Merchandise"].ToString(),
							float.Parse(_Reader["Point"].ToString()));
						}
						Points _Point = new Points();
						_Point.PointId = Guid.Parse(_Reader["PointId"].ToString());
						_Point.Debit = (!string.IsNullOrEmpty(_Reader["Debit"].ToString()) ? float.Parse(_Reader["Debit"].ToString()) : 0);
						_Point.Credit = (!string.IsNullOrEmpty(_Reader["Credit"].ToString()) ? float.Parse(_Reader["Credit"].ToString()) : 0);
						_Point.Created = DateTime.Parse(_Reader["Created"].ToString());
						_Point.Description = _Reader["Description"].ToString();
						_Point.Weight = (!string.IsNullOrEmpty(_Reader["Weight"].ToString()) ? int.Parse(_Reader["Weight"].ToString()) : 0);

						_Value.Add(new Points(
							_Point,
							null,
							_Product
							)
						);
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
