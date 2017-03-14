using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class Networks
    {
		#region Properties
		public int NetworkId { get; set; }
		public string Name { get; set; }
		public string PasswordHash { get; set; }
		public bool IsConnected { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime LastUpdate { get; set; }
        #endregion

        #region Add
        /// <summary>
        /// Adds a new record.
        /// </summary>
        public async void Add()
        {
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                String sql = @"INSERT INTO [Connections]
								(
									[Name],
									[PasswordHash],
									[IsConnected],
									[DateCreated],
									[LastUpdate]
								)
								VALUES
								(
									@Name,
									@PasswordHash,
									@IsConnected,
									@DateCreated,
									@LastUpdate
								);";

                sql += "SELECT SCOPE_IDENTITY();";

                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name;
                    cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, -1).Value = PasswordHash == null ? (Object)DBNull.Value : PasswordHash;
                    cmd.Parameters.Add("@IsConnected", SqlDbType.Bit, 1).Value = IsConnected;
                    cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
                    cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;
                    NetworkId = Convert.ToInt32(await cmd.ExecuteScalarAsync());
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
				String sql =  @"UPDATE	[Networks]
								SET		[Name] = @Name,
										[PasswordHash] = @PasswordHash,
										[IsConnected] = @IsConnected,
										[DateCreated] = @DateCreated,
										[LastUpdate] = @LastUpdate
								WHERE	[ConnectionId] = @ConnectionId;";

                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@NetworkId", SqlDbType.Int, 4).Value = NetworkId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name;
					cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, -1).Value = PasswordHash == null ? (Object)DBNull.Value : PasswordHash;
					cmd.Parameters.Add("@IsConnected", SqlDbType.Bit, 1).Value = IsConnected;
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
		public static async Task Delete(int connectionId)
		{
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"DELETE	FROM [Networks]
								WHERE	[ConnectionId] = @ConnectionId;";

                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@ConnectionId", SqlDbType.Int, 4).Value = connectionId;
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
		public static async Task<Networks> Get(int networkId)
		{
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[NetworkId],
										[Name],
										[PasswordHash],
										[IsConnected],
										[DateCreated],
										[LastUpdate]
								FROM	[Connections]
								WHERE	[ConnectionId] = @NetworkId;";

				Networks networks = new Networks();

                await con.OpenAsync();

                using (SqlCommand cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@NetworkId", SqlDbType.Int, 4).Value = networkId;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
                            networks.NetworkId = Convert.ToInt32(reader["NetworkId"]);
                            networks.Name = reader["Name"].ToString();
                            networks.PasswordHash = reader["PasswordHash"] == DBNull.Value ? null : reader["PasswordHash"].ToString();
                            networks.IsConnected = Convert.ToBoolean(reader["IsConnected"]);
                            networks.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                            networks.LastUpdate = Convert.ToDateTime(reader["LastUpdate"]);
						}
					}
				}

				return networks;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<Networks>> GetAll()
		{
		    var networkList = new List<Networks>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (SqlConnection con = new SqlConnection(connectionString))
			{
                await con.OpenAsync();
                String sql =  @"SELECT	[NetworkId],
										[Name],
										[PasswordHash],
										[IsConnected],
										[DateCreated],
										[LastUpdate]
								FROM	[Connections];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return networkList;
                        while (await reader.ReadAsync())
                        {
                            var network = new Networks
                            {
                                NetworkId = Convert.ToInt32(reader["NetworkId"]),
                                Name = reader["Name"].ToString(),
                                PasswordHash = reader["PasswordHash"] == DBNull.Value ? null : reader["PasswordHash"].ToString(),
                                IsConnected = Convert.ToBoolean(reader["IsConnected"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                LastUpdate = Convert.ToDateTime(reader["LastUpdate"])
                            };
                            networkList.Add(network);
                        }
                    }
				}

				return networkList;
			}
		}
		#endregion
	}
}