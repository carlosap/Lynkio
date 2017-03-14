using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class SensorClaims
	{
		#region Properties
		public int Id { get; set; }
		public int ProductId { get; set; }
		public string Name { get; set; }
		public string Value { get; set; }
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
				String sql =  @"INSERT INTO [SensorClaims]
								(
									[Id],
									[ProductId],
									[Name],
									[Value]
								)
								VALUES
								(
									@Id,
									@ProductId,
									@Name,
									@Value
								);";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = ProductId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, -1).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@Value", SqlDbType.NVarChar, -1).Value = Value == null ? (Object)DBNull.Value : Value;
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
				String sql =  @"UPDATE	[SensorClaims]
								SET		[ProductId] = @ProductId,
										[Name] = @Name,
										[Value] = @Value
								WHERE	[Id] = @Id;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = ProductId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, -1).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@Value", SqlDbType.NVarChar, -1).Value = Value == null ? (Object)DBNull.Value : Value;
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
				String sql =  @"DELETE	FROM [SensorClaims]
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
		public static async Task<SensorClaims> Get(int id)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[Id],
										[ProductId],
										[Name],
										[Value]
								FROM	[SensorClaims]
								WHERE	[Id] = @Id;";

				SensorClaims sensorClaims = new SensorClaims();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							sensorClaims.Id = Convert.ToInt32(reader["Id"]);
							sensorClaims.ProductId = Convert.ToInt32(reader["ProductId"]);
							sensorClaims.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
							sensorClaims.Value = reader["Value"] == DBNull.Value ? null : reader["Value"].ToString();
						}
					}
				}

				return sensorClaims;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<SensorClaims>> GetAll()
		{
            var sensorClaims = new List<SensorClaims>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				await con.OpenAsync();

				String sql =  @"SELECT	[Id],
										[ProductId],
										[Name],
										[Value]
								FROM	[SensorClaims];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return sensorClaims;
                        while (await reader.ReadAsync())
                        {
                            var sensorclaim = new SensorClaims
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                Value = reader["Value"] == DBNull.Value ? null : reader["Value"].ToString()
                            };
                            sensorClaims.Add(sensorclaim);
                        }
                    }
				}
				return sensorClaims;
			}
		}
		#endregion
	}
}