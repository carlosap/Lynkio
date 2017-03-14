using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class Sensors
	{
		#region Properties
		public int SensorId { get; set; }
		public int? ProductId { get; set; }
		public string Name { get; set; }
		public string SensorType { get; set; }
		public string CRD { get; set; }
		public string Unit { get; set; }
		public string Symbol { get; set; }
		public string PartNumber { get; set; }
		public string SensorVersion { get; set; }
		public decimal? Nominal { get; set; }
		public decimal? LastMeasValue { get; set; }
		public decimal? MaxValue { get; set; }
		public decimal? MinValue { get; set; }
		public string OutOfLimitMsg { get; set; }
		public string Descriptions { get; set; }
		public string Lot { get; set; }
		public string Revision { get; set; }
		public string Datecode { get; set; }
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
				String sql =  @"INSERT INTO [Sensors]
								(
									[ProductId],
									[Name],
									[SensorType],
									[CRD],
									[Unit],
									[Symbol],
									[PartNumber],
									[SensorVersion],
									[Nominal],
									[LastMeasValue],
									[MaxValue],
									[MinValue],
									[OutOfLimitMsg],
									[Descriptions],
									[Lot],
									[Revision],
									[Datecode]
								)
								VALUES
								(
									@ProductId,
									@Name,
									@SensorType,
									@CRD,
									@Unit,
									@Symbol,
									@PartNumber,
									@SensorVersion,
									@Nominal,
									@LastMeasValue,
									@MaxValue,
									@MinValue,
									@OutOfLimitMsg,
									@Descriptions,
									@Lot,
									@Revision,
									@Datecode
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = ProductId == null ? (Object)DBNull.Value : ProductId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@SensorType", SqlDbType.NVarChar, 256).Value = SensorType == null ? (Object)DBNull.Value : SensorType;
					cmd.Parameters.Add("@CRD", SqlDbType.NVarChar, 256).Value = CRD == null ? (Object)DBNull.Value : CRD;
					cmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 256).Value = Unit == null ? (Object)DBNull.Value : Unit;
					cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar, 256).Value = Symbol == null ? (Object)DBNull.Value : Symbol;
					cmd.Parameters.Add("@PartNumber", SqlDbType.NVarChar, 256).Value = PartNumber == null ? (Object)DBNull.Value : PartNumber;
					cmd.Parameters.Add("@SensorVersion", SqlDbType.NVarChar, 256).Value = SensorVersion == null ? (Object)DBNull.Value : SensorVersion;
					cmd.Parameters.Add("@Nominal", SqlDbType.Decimal).Value = Nominal == null ? (Object)DBNull.Value : Nominal;
					cmd.Parameters.Add("@LastMeasValue", SqlDbType.Decimal).Value = LastMeasValue == null ? (Object)DBNull.Value : LastMeasValue;
					cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = MaxValue == null ? (Object)DBNull.Value : MaxValue;
					cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = MinValue == null ? (Object)DBNull.Value : MinValue;
					cmd.Parameters.Add("@OutOfLimitMsg", SqlDbType.NVarChar, -1).Value = OutOfLimitMsg == null ? (Object)DBNull.Value : OutOfLimitMsg;
					cmd.Parameters.Add("@Descriptions", SqlDbType.NVarChar, -1).Value = Descriptions == null ? (Object)DBNull.Value : Descriptions;
					cmd.Parameters.Add("@Lot", SqlDbType.NVarChar, 256).Value = Lot == null ? (Object)DBNull.Value : Lot;
					cmd.Parameters.Add("@Revision", SqlDbType.NVarChar, 256).Value = Revision == null ? (Object)DBNull.Value : Revision;
					cmd.Parameters.Add("@Datecode", SqlDbType.NVarChar, 256).Value = Datecode == null ? (Object)DBNull.Value : Datecode;

					// Execute the insert statement and get value of the identity column.
					SensorId = Convert.ToInt32(cmd.ExecuteScalarAsync());
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
				String sql =  @"UPDATE	[Sensors]
								SET		[ProductId] = @ProductId,
										[Name] = @Name,
										[SensorType] = @SensorType,
										[CRD] = @CRD,
										[Unit] = @Unit,
										[Symbol] = @Symbol,
										[PartNumber] = @PartNumber,
										[SensorVersion] = @SensorVersion,
										[Nominal] = @Nominal,
										[LastMeasValue] = @LastMeasValue,
										[MaxValue] = @MaxValue,
										[MinValue] = @MinValue,
										[OutOfLimitMsg] = @OutOfLimitMsg,
										[Descriptions] = @Descriptions,
										[Lot] = @Lot,
										[Revision] = @Revision,
										[Datecode] = @Datecode
								WHERE	[SensorId] = @SensorId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@SensorId", SqlDbType.Int, 4).Value = SensorId;
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = ProductId == null ? (Object)DBNull.Value : ProductId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@SensorType", SqlDbType.NVarChar, 256).Value = SensorType == null ? (Object)DBNull.Value : SensorType;
					cmd.Parameters.Add("@CRD", SqlDbType.NVarChar, 256).Value = CRD == null ? (Object)DBNull.Value : CRD;
					cmd.Parameters.Add("@Unit", SqlDbType.NVarChar, 256).Value = Unit == null ? (Object)DBNull.Value : Unit;
					cmd.Parameters.Add("@Symbol", SqlDbType.NVarChar, 256).Value = Symbol == null ? (Object)DBNull.Value : Symbol;
					cmd.Parameters.Add("@PartNumber", SqlDbType.NVarChar, 256).Value = PartNumber == null ? (Object)DBNull.Value : PartNumber;
					cmd.Parameters.Add("@SensorVersion", SqlDbType.NVarChar, 256).Value = SensorVersion == null ? (Object)DBNull.Value : SensorVersion;
					cmd.Parameters.Add("@Nominal", SqlDbType.Decimal).Value = Nominal == null ? (Object)DBNull.Value : Nominal;
					cmd.Parameters.Add("@LastMeasValue", SqlDbType.Decimal).Value = LastMeasValue == null ? (Object)DBNull.Value : LastMeasValue;
					cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = MaxValue == null ? (Object)DBNull.Value : MaxValue;
					cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = MinValue == null ? (Object)DBNull.Value : MinValue;
					cmd.Parameters.Add("@OutOfLimitMsg", SqlDbType.NVarChar, -1).Value = OutOfLimitMsg == null ? (Object)DBNull.Value : OutOfLimitMsg;
					cmd.Parameters.Add("@Descriptions", SqlDbType.NVarChar, -1).Value = Descriptions == null ? (Object)DBNull.Value : Descriptions;
					cmd.Parameters.Add("@Lot", SqlDbType.NVarChar, 256).Value = Lot == null ? (Object)DBNull.Value : Lot;
					cmd.Parameters.Add("@Revision", SqlDbType.NVarChar, 256).Value = Revision == null ? (Object)DBNull.Value : Revision;
					cmd.Parameters.Add("@Datecode", SqlDbType.NVarChar, 256).Value = Datecode == null ? (Object)DBNull.Value : Datecode;
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
		public static async Task Delete(int sensorId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"DELETE	FROM [Sensors]
								WHERE	[SensorId] = @SensorId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@SensorId", SqlDbType.Int, 4).Value = sensorId;
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
		public static async Task<Sensors> Get(int sensorId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[SensorId],
										[ProductId],
										[Name],
										[SensorType],
										[CRD],
										[Unit],
										[Symbol],
										[PartNumber],
										[SensorVersion],
										[Nominal],
										[LastMeasValue],
										[MaxValue],
										[MinValue],
										[OutOfLimitMsg],
										[Descriptions],
										[Lot],
										[Revision],
										[Datecode]
								FROM	[Sensors]
								WHERE	[SensorId] = @SensorId;";

				Sensors sensors = new Sensors();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@SensorId", SqlDbType.Int, 4).Value = sensorId;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							sensors.SensorId = Convert.ToInt32(reader["SensorId"]);
							sensors.ProductId = reader["ProductId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ProductId"]);
							sensors.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
							sensors.SensorType = reader["SensorType"] == DBNull.Value ? null : reader["SensorType"].ToString();
							sensors.CRD = reader["CRD"] == DBNull.Value ? null : reader["CRD"].ToString();
							sensors.Unit = reader["Unit"] == DBNull.Value ? null : reader["Unit"].ToString();
							sensors.Symbol = reader["Symbol"] == DBNull.Value ? null : reader["Symbol"].ToString();
							sensors.PartNumber = reader["PartNumber"] == DBNull.Value ? null : reader["PartNumber"].ToString();
							sensors.SensorVersion = reader["SensorVersion"] == DBNull.Value ? null : reader["SensorVersion"].ToString();
							sensors.Nominal = reader["Nominal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Nominal"]);
							sensors.LastMeasValue = reader["LastMeasValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["LastMeasValue"]);
							sensors.MaxValue = reader["MaxValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MaxValue"]);
							sensors.MinValue = reader["MinValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MinValue"]);
							sensors.OutOfLimitMsg = reader["OutOfLimitMsg"] == DBNull.Value ? null : reader["OutOfLimitMsg"].ToString();
							sensors.Descriptions = reader["Descriptions"] == DBNull.Value ? null : reader["Descriptions"].ToString();
							sensors.Lot = reader["Lot"] == DBNull.Value ? null : reader["Lot"].ToString();
							sensors.Revision = reader["Revision"] == DBNull.Value ? null : reader["Revision"].ToString();
							sensors.Datecode = reader["Datecode"] == DBNull.Value ? null : reader["Datecode"].ToString();
						}
					}
				}

				return sensors;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<Sensors>> GetAll()
		{
            var sensors = new List<Sensors>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{

				await con.OpenAsync();
				String sql =  @"SELECT	[SensorId],
										[ProductId],
										[Name],
										[SensorType],
										[CRD],
										[Unit],
										[Symbol],
										[PartNumber],
										[SensorVersion],
										[Nominal],
										[LastMeasValue],
										[MaxValue],
										[MinValue],
										[OutOfLimitMsg],
										[Descriptions],
										[Lot],
										[Revision],
										[Datecode]
								FROM	[Sensors];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return sensors;
                        while (await reader.ReadAsync())
                        {
                            var sensor = new Sensors
                            {
                                SensorId = Convert.ToInt32(reader["SensorId"]),
                                ProductId = reader["ProductId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ProductId"]),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                SensorType = reader["SensorType"] == DBNull.Value ? null : reader["SensorType"].ToString(),
                                CRD = reader["CRD"] == DBNull.Value ? null : reader["CRD"].ToString(),
                                Unit = reader["Unit"] == DBNull.Value ? null : reader["Unit"].ToString(),
                                Symbol = reader["Symbol"] == DBNull.Value ? null : reader["Symbol"].ToString(),
                                PartNumber = reader["PartNumber"] == DBNull.Value ? null : reader["PartNumber"].ToString(),
                                SensorVersion = reader["SensorVersion"] == DBNull.Value ? null : reader["SensorVersion"].ToString(),
                                Nominal = reader["Nominal"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["Nominal"]),
                                LastMeasValue = reader["LastMeasValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["LastMeasValue"]),
                                MaxValue = reader["MaxValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MaxValue"]),
                                MinValue = reader["MinValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MinValue"]),
                                OutOfLimitMsg = reader["OutOfLimitMsg"] == DBNull.Value ? null : reader["OutOfLimitMsg"].ToString(),
                                Descriptions = reader["Descriptions"] == DBNull.Value ? null : reader["Descriptions"].ToString(),
                                Lot = reader["Lot"] == DBNull.Value ? null : reader["Lot"].ToString(),
                                Revision = reader["Revision"] == DBNull.Value ? null : reader["Revision"].ToString(),
                                Datecode = reader["Datecode"] == DBNull.Value ? null : reader["Datecode"].ToString()
                            };
                            sensors.Add(sensor);
                        }
                    }
				}
				return sensors;
			}
		}
		#endregion
	}
}