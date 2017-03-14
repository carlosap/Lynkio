using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class UserRoles
	{
		#region Properties
		public int UserId { get; set; }
		public int RoleId { get; set; }
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
				String sql =  @"INSERT INTO [UserRoles]
								(
									[UserId],
									[RoleId]
								)
								VALUES
								(
									@UserId,
									@RoleId
								);";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId;
					cmd.Parameters.Add("@RoleId", SqlDbType.Int, 4).Value = RoleId;
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
		public static async Task Delete(int userId, int roleId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"DELETE	FROM [UserRoles]
								WHERE	[UserId] = @UserId
								AND		[RoleId] = @RoleId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userId;
					cmd.Parameters.Add("@RoleId", SqlDbType.Int, 4).Value = roleId;
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
		public static async Task<UserRoles> Get(int userId, int roleId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[UserId],
										[RoleId]
								FROM	[UserRoles]
								WHERE	[UserId] = @UserId
								AND		[RoleId] = @RoleId;";

				UserRoles userRoles = new UserRoles();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userId;
					cmd.Parameters.Add("@RoleId", SqlDbType.Int, 4).Value = roleId;
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							userRoles.UserId = Convert.ToInt32(reader["UserId"]);
							userRoles.RoleId = Convert.ToInt32(reader["RoleId"]);
						}
					}
				}

				return userRoles;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<UserRoles>> GetAll()
		{
            var roles = new List<UserRoles>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{

				await con.OpenAsync();
				String sql =  @"SELECT	[UserId],
										[RoleId]
								FROM	[UserRoles];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return roles;
                        while (await reader.ReadAsync())
                        {
                            var role = new UserRoles
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                RoleId = Convert.ToInt32(reader["RoleId"])
                            };
                            roles.Add(role);
                        }
                    }
				}
				return roles;
			}
		}
		#endregion
	}
}