using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class SensorSettings
	{
		#region Properties
		public int Id { get; set; }
		public int? SensorId { get; set; }
		public decimal? MinValue { get; set; }
		public decimal? MaxValue { get; set; }
		public string ExpectedPhrase { get; set; }
		public string Descriptions { get; set; }
		public string ErrorMessage { get; set; }
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
            using (var con = new SqlConnection(connectionString))
            {
                var sql = @"INSERT INTO [SensorSettings]
								(
									[SensorId],
									[MinValue],
									[MaxValue],
									[ExpectedPhrase],
									[Descriptions],
									[ErrorMessage],
									[DateCreated],
									[LastUpdate]
								)
								VALUES
								(
									@SensorId,
									@MinValue,
									@MaxValue,
									@ExpectedPhrase,
									@Descriptions,
									@ErrorMessage,
									@DateCreated,
									@LastUpdate
								);";

                sql += "SELECT SCOPE_IDENTITY();";
                await con.OpenAsync();
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@SensorId", SqlDbType.Int, 4).Value = SensorId == null ? (Object)DBNull.Value : SensorId;
                    cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = MinValue == null ? (Object)DBNull.Value : MinValue;
                    cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = MaxValue == null ? (Object)DBNull.Value : MaxValue;
                    cmd.Parameters.Add("@ExpectedPhrase", SqlDbType.NVarChar, 256).Value = ExpectedPhrase == null ? (Object)DBNull.Value : ExpectedPhrase;
                    cmd.Parameters.Add("@Descriptions", SqlDbType.NVarChar, -1).Value = Descriptions == null ? (Object)DBNull.Value : Descriptions;
                    cmd.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, -1).Value = ErrorMessage == null ? (Object)DBNull.Value : ErrorMessage;
                    cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
                    cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;
                    Id = Convert.ToInt32(cmd.ExecuteScalarAsync());
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
            using (var con = new SqlConnection(connectionString))
			{
				var sql =  @"UPDATE	[SensorSettings]
								SET		[SensorId] = @SensorId,
										[MinValue] = @MinValue,
										[MaxValue] = @MaxValue,
										[ExpectedPhrase] = @ExpectedPhrase,
										[Descriptions] = @Descriptions,
										[ErrorMessage] = @ErrorMessage,
										[DateCreated] = @DateCreated,
										[LastUpdate] = @LastUpdate
								WHERE	[Id] = @Id;";

                await con.OpenAsync();
                using (var cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = Id;
					cmd.Parameters.Add("@SensorId", SqlDbType.Int, 4).Value = SensorId == null ? (Object)DBNull.Value : SensorId;
					cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = MinValue == null ? (Object)DBNull.Value : MinValue;
					cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = MaxValue == null ? (Object)DBNull.Value : MaxValue;
					cmd.Parameters.Add("@ExpectedPhrase", SqlDbType.NVarChar, 256).Value = ExpectedPhrase == null ? (Object)DBNull.Value : ExpectedPhrase;
					cmd.Parameters.Add("@Descriptions", SqlDbType.NVarChar, -1).Value = Descriptions == null ? (Object)DBNull.Value : Descriptions;
					cmd.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, -1).Value = ErrorMessage == null ? (Object)DBNull.Value : ErrorMessage;
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
		public static async Task Delete(int id)
		{
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
			{
				var sql =  @"DELETE	FROM [SensorSettings]
								WHERE	[Id] = @Id;";

                await con.OpenAsync();
                using (var cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;
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
		public static async Task<SensorSettings> Get(int id)
		{
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
			{
				var sql =  @"SELECT	[Id],
										[SensorId],
										[MinValue],
										[MaxValue],
										[ExpectedPhrase],
										[Descriptions],
										[ErrorMessage],
										[DateCreated],
										[LastUpdate]
								FROM	[SensorSettings]
								WHERE	[Id] = @Id;";

				var sensorSettings = new SensorSettings();
                await con.OpenAsync();
                using (var cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    cmd.Parameters.Add("@Id", SqlDbType.Int, 4).Value = id;
					using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							sensorSettings.Id = Convert.ToInt32(reader["Id"]);
							sensorSettings.SensorId = reader["SensorId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SensorId"]);
							sensorSettings.MinValue = reader["MinValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MinValue"]);
							sensorSettings.MaxValue = reader["MaxValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MaxValue"]);
							sensorSettings.ExpectedPhrase = reader["ExpectedPhrase"] == DBNull.Value ? null : reader["ExpectedPhrase"].ToString();
							sensorSettings.Descriptions = reader["Descriptions"] == DBNull.Value ? null : reader["Descriptions"].ToString();
							sensorSettings.ErrorMessage = reader["ErrorMessage"] == DBNull.Value ? null : reader["ErrorMessage"].ToString();
							sensorSettings.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
							sensorSettings.LastUpdate = Convert.ToDateTime(reader["LastUpdate"]);
						}
					}
				}

				return sensorSettings;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<SensorSettings>> GetAll()
		{
            var settings = new List<SensorSettings>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
            using (var con = new SqlConnection(connectionString))
			{
                await con.OpenAsync();
                var sql =  @"SELECT	[Id],
										[SensorId],
										[MinValue],
										[MaxValue],
										[ExpectedPhrase],
										[Descriptions],
										[ErrorMessage],
										[DateCreated],
										[LastUpdate]
								FROM	[SensorSettings];";

				using (var cmd = new SqlCommand(sql, con))
				{
                    cmd.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return settings;
                        while (await reader.ReadAsync())
                        {
                            var setting = new SensorSettings
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                SensorId = reader["SensorId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SensorId"]),
                                MinValue = reader["MinValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MinValue"]),
                                MaxValue = reader["MaxValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MaxValue"]),
                                ExpectedPhrase = reader["ExpectedPhrase"] == DBNull.Value ? null : reader["ExpectedPhrase"].ToString(),
                                Descriptions = reader["Descriptions"] == DBNull.Value ? null : reader["Descriptions"].ToString(),
                                ErrorMessage = reader["ErrorMessage"] == DBNull.Value ? null : reader["ErrorMessage"].ToString(),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                LastUpdate = Convert.ToDateTime(reader["LastUpdate"])
                            };
                            settings.Add(setting);
                        }
                    }
				}

				return settings;
			}
		}
		#endregion
	}
}