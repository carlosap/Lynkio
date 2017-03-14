using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class UserLogins
	{
		#region Properties
		public int Id { get; set; }
		public int UserId { get; set; }
		public string ProviderName { get; set; }
		public string ProviderKey { get; set; }
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
				var sql =  @"INSERT INTO [UserLogins]
								(
									[Id],
									[UserId],
									[ProviderName],
									[ProviderKey]
								)
								VALUES
								(
									@Id,
									@UserId,
									@ProviderName,
									@ProviderKey
								);";

				await con.OpenAsync();
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId;
					cmd.Parameters.Add("@ProviderName", SqlDbType.NVarChar, 256).Value = ProviderName;
					cmd.Parameters.Add("@ProviderKey", SqlDbType.NVarChar, 256).Value = ProviderKey;
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
				var sql =  @"UPDATE	[UserLogins]
								SET		[UserId] = @UserId,
										[ProviderName] = @ProviderName,
										[ProviderKey] = @ProviderKey
								WHERE	[Id] = @Id;";

				await con.OpenAsync();
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId;
					cmd.Parameters.Add("@ProviderName", SqlDbType.NVarChar, 256).Value = ProviderName;
					cmd.Parameters.Add("@ProviderKey", SqlDbType.NVarChar, 256).Value = ProviderKey;
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
				var sql =  @"DELETE	FROM [UserLogins]
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
		public static async Task<UserLogins> Get(int id)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				var sql =  @"SELECT	[Id],
										[UserId],
										[ProviderName],
										[ProviderKey]
								FROM	[UserLogins]
								WHERE	[Id] = @Id;";

				UserLogins userLogins = new UserLogins();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							userLogins.Id = Convert.ToInt32(reader["Id"]);
							userLogins.UserId = Convert.ToInt32(reader["UserId"]);
							userLogins.ProviderName = reader["ProviderName"].ToString();
							userLogins.ProviderKey = reader["ProviderKey"].ToString();
						}
					}
				}

				return userLogins;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<UserLogins>> GetAll()
		{
            var logins = new List<UserLogins>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				await con.OpenAsync();
				var sql =  @"SELECT	[Id],
										[UserId],
										[ProviderName],
										[ProviderKey]
								FROM	[UserLogins];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return logins;
                        while (await reader.ReadAsync())
                        {
                            var user = new UserLogins
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                UserId = Convert.ToInt32(reader["UserId"]),
                                ProviderName = reader["ProviderName"].ToString(),
                                ProviderKey = reader["ProviderKey"].ToString()
                            };
                            logins.Add(user);
                        }
                    }
				}

				return logins;
			}
		}
		#endregion
	}
}