using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class UserClaims
	{
		#region Properties
		public int Id { get; set; }
		public int UserId { get; set; }
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
				String sql =  @"INSERT INTO [UserClaims]
								(
									[Id],
									[UserId],
									[Name],
									[Value]
								)
								VALUES
								(
									@Id,
									@UserId,
									@Name,
									@Value
								);";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId;
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
				String sql =  @"UPDATE	[UserClaims]
								SET		[UserId] = @UserId,
										[Name] = @Name,
										[Value] = @Value
								WHERE	[Id] = @Id;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId;
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
				String sql =  @"DELETE	FROM [UserClaims]
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
		public static async Task<UserClaims> Get(int id)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[Id],
										[UserId],
										[Name],
										[Value]
								FROM	[UserClaims]
								WHERE	[Id] = @Id;";

				UserClaims userClaims = new UserClaims();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							userClaims.Id = Convert.ToInt32(reader["Id"]);
							userClaims.UserId = Convert.ToInt32(reader["UserId"]);
							userClaims.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
							userClaims.Value = reader["Value"] == DBNull.Value ? null : reader["Value"].ToString();
						}
					}
				}
				return userClaims;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<UserClaims>> GetAll()
		{
            var userClaims = new List<UserClaims>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				await con.OpenAsync();
				String sql =  @"SELECT	[Id],
										[UserId],
										[Name],
										[Value]
								FROM	[UserClaims];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return userClaims;
                        while (await reader.ReadAsync())
                        {
                            var userClaim = new UserClaims
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                Value = reader["Value"] == DBNull.Value ? null : reader["Value"].ToString()
                            };
                            userClaims.Add(userClaim);
                        }
                    }
				}
				return userClaims;
			}
		}
		#endregion
	}
}