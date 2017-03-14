using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class HistogramClaims
	{
		#region Properties
		public int Id { get; set; }
		public int HistogramId { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime LastUpdate { get; set; }
		#endregion

		#region Add
		/// <summary>
		/// Adds a new record.
		/// </summary>
		public async Task Add()
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"INSERT INTO [HistogramClaims]
								(
									[Id],
									[HistogramId],
									[Name],
									[Value],
									[DateCreated],
									[LastUpdate]
								)
								VALUES
								(
									@Id,
									@HistogramId,
									@Name,
									@Value,
									@DateCreated,
									@LastUpdate
								);";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@HistogramId", SqlDbType.Int, 4).Value = HistogramId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, -1).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@Value", SqlDbType.NVarChar, -1).Value = Value == null ? (Object)DBNull.Value : Value;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
					cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;
					await cmd.ExecuteNonQueryAsync();;
				}

				con.Close();
			}
		}
		#endregion

		#region Update
		/// <summary>
		/// Updates an existing record.
		/// </summary>
		public async Task Update()
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"UPDATE	[HistogramClaims]
								SET		[HistogramId] = @HistogramId,
										[Name] = @Name,
										[Value] = @Value,
										[DateCreated] = @DateCreated,
										[LastUpdate] = @LastUpdate
								WHERE	[Id] = @Id;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@HistogramId", SqlDbType.Int, 4).Value = HistogramId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, -1).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@Value", SqlDbType.NVarChar, -1).Value = Value == null ? (Object)DBNull.Value : Value;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
					cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;
					await cmd.ExecuteNonQueryAsync();;
				}

				con.Close();
			}
		}
		#endregion

		#region Delete
		/// <summary>
		/// Deletes an existing record.
		/// </summary>
		public static async Task Delete(int id)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"DELETE	FROM [HistogramClaims]
								WHERE	[Id] = @Id;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;
					await cmd.ExecuteNonQueryAsync();;
				}

				con.Close();
			}
		}
		#endregion

		#region Get
		/// <summary>
		/// Gets an existing record.
		/// </summary>
		public static async Task<HistogramClaims> Get(int id)
		{            
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[Id],
										[HistogramId],
										[Name],
										[Value],
										[DateCreated],
										[LastUpdate]
								FROM	[HistogramClaims]
								WHERE	[Id] = @Id;";

				HistogramClaims histogramClaims = new HistogramClaims();
				await con.OpenAsync();
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							histogramClaims.Id = Convert.ToInt32(reader["Id"]);
							histogramClaims.HistogramId = Convert.ToInt32(reader["HistogramId"]);
							histogramClaims.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
							histogramClaims.Value = reader["Value"] == DBNull.Value ? null : reader["Value"].ToString();
							histogramClaims.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
							histogramClaims.LastUpdate = Convert.ToDateTime(reader["LastUpdate"]);
						}
					}
				}
				return histogramClaims;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<HistogramClaims>> GetAll()
		{
            var histogramList = new List<HistogramClaims>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				await con.OpenAsync();
				String sql =  @"SELECT	[Id],
										[HistogramId],
										[Name],
										[Value],
										[DateCreated],
										[LastUpdate]
								FROM	[HistogramClaims];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return histogramList;
                        while (await reader.ReadAsync())
                        {
                            var histogram = new HistogramClaims
                            {
                                
                                HistogramId = Convert.ToInt32(reader["HistogramId"]),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                Value = reader["Value"] == DBNull.Value ? null : reader["Value"].ToString(),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                LastUpdate = Convert.ToDateTime(reader["LastUpdate"]),
                            };
                            histogramList.Add(histogram);
                        }
                    }
				}
				return histogramList;
			}
		}
		#endregion
	}
}