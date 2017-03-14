using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class Roles
	{
		#region Properties
		public int RoleId { get; set; }
		public string Name { get; set; }
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
				var sql =  @"INSERT INTO [Roles]
								(
									[Name],
									[DateCreated],
									[LastUpdate]
								)
								VALUES
								(
									@Name,
									@DateCreated,
									@LastUpdate
								);";

				sql += "SELECT SCOPE_IDENTITY();";
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
					cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;

					// Execute the insert statement and get value of the identity column.
					RoleId = Convert.ToInt32(cmd.ExecuteScalarAsync());
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
				var sql =  @"UPDATE	[Roles]
								SET		[Name] = @Name,
										[DateCreated] = @DateCreated,
										[LastUpdate] = @LastUpdate
								WHERE	[RoleId] = @RoleId;";

                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@RoleId", SqlDbType.Int, 4).Value = RoleId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
					cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;
					await cmd.ExecuteNonQueryAsync();
				}

				con.Close();
			}
		}
        #endregion

        #region Delete
        /// <summary>
        /// Deletes an existing record.
        /// </summary>
        public async Task Delete(int roleId)
        {
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                var sql = @"DELETE	FROM [Roles]
								WHERE	[RoleId] = @RoleId;";

                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@RoleId", SqlDbType.Int, 4).Value = roleId;
                    await cmd.ExecuteNonQueryAsync();
                }
                con.Close();
            }
        }
        #endregion

        #region Get
        /// <summary>
        /// Gets an existing record.
        /// </summary>
        public async Task<Roles> Get(int roleId)
        {
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"SELECT	[RoleId],
										[Name],
										[DateCreated],
										[LastUpdate]
								FROM	[Roles]
								WHERE	[RoleId] = @RoleId;";

                Roles roles = new Roles();
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@RoleId", SqlDbType.Int, 4).Value = roleId;
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (!reader.Read()) return roles;
                        roles.RoleId = Convert.ToInt32(reader["RoleId"]);
                        roles.Name = reader["Name"].ToString();
                        roles.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                        roles.LastUpdate = Convert.ToDateTime(reader["LastUpdate"]);
                    }
                }
                return roles;
            }
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Gets all records.
        /// </summary>
        public async Task<List<Roles>> GetAll()
        {
            var roleList = new List<Roles>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
			{
                await con.OpenAsync();
                String sql =  @"SELECT	[RoleId],
										[Name],
										[DateCreated],
										[LastUpdate]
								FROM	[Roles];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
					    if (!reader.HasRows) return roleList;
					    while (await reader.ReadAsync())
					    {
					        var role = new Roles
					        {
					            RoleId = Convert.ToInt32(reader["RoleId"]),
					            Name = reader["Name"].ToString(),
					            DateCreated = Convert.ToDateTime(reader["DateCreated"]),
					            LastUpdate = Convert.ToDateTime(reader["LastUpdate"])
					        };
					        roleList.Add(role);
					    }
					}
                }
				return roleList;
			}
		}
		#endregion
	}
}