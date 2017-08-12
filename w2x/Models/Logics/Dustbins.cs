using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using w2x.Models.Configurations;

namespace w2x.Models.Logics
{
	public class Dustbins
	{
		public Guid DustbinId { get; set; }
		public String LocationName { get; set; }
		public float Percentage { get; set; }
		public DustbinTransaction Transaction { get; set; }
		public Dustbins() { }
		public Dustbins(Guid DustbinId, String LocationName, float Percentage)
		{
			this.DustbinId = DustbinId;
			this.LocationName = LocationName;
			this.Percentage = Percentage;
		}

		public static List<Dustbins> GetAllDustbin()
		{
			List<Dustbins> _Value = new List<Dustbins>();

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "GetAllDustbin";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Conn.Open();

				SqlDataReader _Reader = _Cmd.ExecuteReader();

				try
				{
					while (_Reader.Read())
					{
						_Value.Add(new Dustbins(
							Guid.Parse(_Reader["DustbinId"].ToString()),
							_Reader["LocationName"].ToString(),
							float.Parse(_Reader["Percentage"].ToString())
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



		public static float IdentifyOverallKPI()
		{
			float _Value = 0;

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "GetKpiPercentage";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Conn.Open();

				SqlDataReader _Reader = _Cmd.ExecuteReader();

				try
				{
					while (_Reader.Read())
					{
						_Value = float.Parse(_Reader["AveragePercentage"].ToString());
					}
				}
				finally
				{
					_Conn.Close();
				}

			}

			return _Value;
		}

		public static List<Dustbins> GetAllCreditTransaction()
		{
			List<Dustbins> _Value = new List<Dustbins>();

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "GetAllCreditDustbin";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Conn.Open();

				SqlDataReader _Reader = _Cmd.ExecuteReader();

				try
				{
					while (_Reader.Read())
					{
						Dustbins _Dustbin = new Dustbins(
							Guid.Parse(_Reader["DustbinId"].ToString()),
							_Reader["LocationName"].ToString(),
							float.Parse(_Reader["Percentage"].ToString()));
						_Dustbin.Transaction = new DustbinTransaction();
						_Dustbin.Transaction.Credit = float.Parse(_Reader["Credit"].ToString());
						_Value.Add(_Dustbin);
					}
				}
				finally
				{
					_Conn.Close();
				}

			}

			return _Value;
		}

		public static async void UpdateMCMCDustbin()
		{
			float _ValuePercentage = 0;
			RootObject _Value = new RootObject();

			var url = "https://api.thingspeak.com/channels/315881/fields/1.json?results=1";
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = WebRequestMethods.Http.Get;
			request.ContentType = "application/json";

			try
			{
				//using (var streamWriter = new StreamWriter(await request.GetRequestStreamAsync()))
				//{
				//	string jsonData = "{\"custUserName\": \"" + _argUsername +
				//		"\", \"custPassword\" : \"" + _argPassword +
				//		"\"}";

				//	streamWriter.Write(jsonData);
				//	streamWriter.Flush();
				//	streamWriter.Close();
				//}

				using (WebResponse response = await request.GetResponseAsync())
				{
					using (Stream responseStream = response.GetResponseStream())
					{
						StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
						_Value = JsonConvert.DeserializeObject<RootObject>(reader.ReadToEnd().Trim());

					}
				}
				_ValuePercentage = float.Parse(_Value.feeds[0].field1);
			}
			catch (WebException ex)
			{
				WebResponse errorResponse = ex.Response;
			}

			using (SqlConnection _Conn = new SqlConnection(Configuration.SQLConnection))
			{
				SqlCommand _Cmd = new SqlCommand();
				_Cmd.CommandText = "UpdateMCMCDustbin";
				_Cmd.CommandType = System.Data.CommandType.StoredProcedure;
				_Cmd.CommandTimeout = 0;
				_Cmd.Connection = _Conn;

				_Cmd.Parameters.AddWithValue("@Percentage", _ValuePercentage);

				_Conn.Open();

				try
				{
					_Cmd.ExecuteNonQuery();
				}
				finally
				{
					_Conn.Close();
				}

			}
		}
	}
}
