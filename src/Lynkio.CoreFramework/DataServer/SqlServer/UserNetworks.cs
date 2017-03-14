using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class UserNetworks
	{
		#region Properties
		public int UserId { get; set; }
		public int NetworkId { get; set; }
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
				var sql =  @"INSERT INTO [UserNetworks]
								(
									[UserId],
									[NetworkId]
								)
								VALUES
								(
									@UserId,
									@NetworkId
								);";

				await con.OpenAsync();
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId;
					cmd.Parameters.Add("@NetworkId", SqlDbType.Int, 4).Value = NetworkId;
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
		public static async Task Delete(int userId, int networkId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				var sql =  @"DELETE	FROM [UserNetworks]
								WHERE	[UserId] = @UserId
								AND		[NetworkId] = @NetworkId;";

				await con.OpenAsync();
				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userId;
					cmd.Parameters.Add("@NetworkId", SqlDbType.Int, 4).Value = networkId;
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
		public static async Task<UserNetworks> Get(int userId, int networkId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				var sql =  @"SELECT	[UserId],
										[NetworkId]
								FROM	[UserNetworks]
								WHERE	[UserId] = @UserId
								AND		[NetworkId] = @NetworkId;";

				UserNetworks userNetworks = new UserNetworks();
				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userId;
					cmd.Parameters.Add("@NetworkId", SqlDbType.Int, 4).Value = networkId;
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							userNetworks.UserId = Convert.ToInt32(reader["UserId"]);
							userNetworks.NetworkId = Convert.ToInt32(reader["NetworkId"]);
						}
					}
				}
				return userNetworks;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<UserNetworks>> GetAll()
		{
            var userConnections = new List<UserNetworks>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{

				await con.OpenAsync();
				var sql =  @"SELECT	[UserId],
										[NetworkId]
								FROM	[UserNetworks];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return userConnections;
                        while (await reader.ReadAsync())
                        {
                            var connection = new UserNetworks
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                NetworkId = Convert.ToInt32(reader["NetworkId"])
                            };
                            userConnections.Add(connection);
                        }
                    }
				}
				return userConnections;
			}
		}
		#endregion
	}
}