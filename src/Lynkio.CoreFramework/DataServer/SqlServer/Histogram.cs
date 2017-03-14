using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class Histogram
	{
		#region Properties
		public int HistogramId { get; set; }
		public int? ReportsTo { get; set; }
		public Guid? RunID { get; set; }
		public int? RunStepNum { get; set; }
		public string Name { get; set; }
		public string Status { get; set; }
		public string Type { get; set; }
		public string Build { get; set; }
		public string Platform { get; set; }
		public string Category { get; set; }
		public string Process { get; set; }
		public string Outcome { get; set; }
		public bool OutcomePassing { get; set; }
		public string OutcomeFilePath { get; set; }
		public string MachineName { get; set; }
		public string RunBy { get; set; }
		public string Description { get; set; }
		public string Dump { get; set; }
		public int ProductId { get; set; }
		public int? SensorId { get; set; }
		public decimal? MeasValue { get; set; }
		public decimal? MaxValue { get; set; }
		public decimal? MinValue { get; set; }
		public string Notes { get; set; }
		public string ErrorMessage { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public DateTime DateCreated { get; set; }
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
				String sql =  @"INSERT INTO [Histogram]
								(
									[ReportsTo],
									[RunID],
									[RunStepNum],
									[Name],
									[Status],
									[Type],
									[Build],
									[Platform],
									[Category],
									[Process],
									[Outcome],
									[OutcomePassing],
									[OutcomeFilePath],
									[MachineName],
									[RunBy],
									[Description],
									[Dump],
									[ProductId],
									[SensorId],
									[MeasValue],
									[MaxValue],
									[MinValue],
									[Notes],
									[ErrorMessage],
									[StartTime],
									[EndTime],
									[DateCreated]
								)
								VALUES
								(
									@ReportsTo,
									@RunID,
									@RunStepNum,
									@Name,
									@Status,
									@Type,
									@Build,
									@Platform,
									@Category,
									@Process,
									@Outcome,
									@OutcomePassing,
									@OutcomeFilePath,
									@MachineName,
									@RunBy,
									@Description,
									@Dump,
									@ProductId,
									@SensorId,
									@MeasValue,
									@MaxValue,
									@MinValue,
									@Notes,
									@ErrorMessage,
									@StartTime,
									@EndTime,
									@DateCreated
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@ReportsTo", SqlDbType.Int, 4).Value = ReportsTo == null ? (Object)DBNull.Value : ReportsTo;
					cmd.Parameters.Add("@RunID", SqlDbType.UniqueIdentifier).Value = RunID == null ? (Object)DBNull.Value : RunID;
					cmd.Parameters.Add("@RunStepNum", SqlDbType.Int, 4).Value = RunStepNum == null ? (Object)DBNull.Value : RunStepNum;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name;
					cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = Status;
					cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = Type == null ? (Object)DBNull.Value : Type;
					cmd.Parameters.Add("@Build", SqlDbType.NVarChar, 50).Value = Build == null ? (Object)DBNull.Value : Build;
					cmd.Parameters.Add("@Platform", SqlDbType.NVarChar, 50).Value = Platform == null ? (Object)DBNull.Value : Platform;
					cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = Category == null ? (Object)DBNull.Value : Category;
					cmd.Parameters.Add("@Process", SqlDbType.NVarChar, 50).Value = Process == null ? (Object)DBNull.Value : Process;
					cmd.Parameters.Add("@Outcome", SqlDbType.NVarChar, 50).Value = Outcome == null ? (Object)DBNull.Value : Outcome;
					cmd.Parameters.Add("@OutcomePassing", SqlDbType.Bit, 1).Value = OutcomePassing;
					cmd.Parameters.Add("@OutcomeFilePath", SqlDbType.NVarChar, 500).Value = OutcomeFilePath == null ? (Object)DBNull.Value : OutcomeFilePath;
					cmd.Parameters.Add("@MachineName", SqlDbType.NVarChar, 50).Value = MachineName == null ? (Object)DBNull.Value : MachineName;
					cmd.Parameters.Add("@RunBy", SqlDbType.NVarChar, 50).Value = RunBy == null ? (Object)DBNull.Value : RunBy;
					cmd.Parameters.Add("@Description", SqlDbType.NVarChar, -1).Value = Description == null ? (Object)DBNull.Value : Description;
					cmd.Parameters.Add("@Dump", SqlDbType.NVarChar, -1).Value = Dump == null ? (Object)DBNull.Value : Dump;
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = ProductId;
					cmd.Parameters.Add("@SensorId", SqlDbType.Int, 4).Value = SensorId == null ? (Object)DBNull.Value : SensorId;
					cmd.Parameters.Add("@MeasValue", SqlDbType.Decimal).Value = MeasValue == null ? (Object)DBNull.Value : MeasValue;
					cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = MaxValue == null ? (Object)DBNull.Value : MaxValue;
					cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = MinValue == null ? (Object)DBNull.Value : MinValue;
					cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, -1).Value = Notes == null ? (Object)DBNull.Value : Notes;
					cmd.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, -1).Value = ErrorMessage == null ? (Object)DBNull.Value : ErrorMessage;
					cmd.Parameters.Add("@StartTime", SqlDbType.DateTime, 8).Value = StartTime;
					cmd.Parameters.Add("@EndTime", SqlDbType.DateTime, 8).Value = EndTime;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;

					// Execute the insert statement and get value of the identity column.
					HistogramId = Convert.ToInt32(cmd.ExecuteScalarAsync());
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
				String sql =  @"UPDATE	[Histogram]
								SET		[ReportsTo] = @ReportsTo,
										[RunID] = @RunID,
										[RunStepNum] = @RunStepNum,
										[Name] = @Name,
										[Status] = @Status,
										[Type] = @Type,
										[Build] = @Build,
										[Platform] = @Platform,
										[Category] = @Category,
										[Process] = @Process,
										[Outcome] = @Outcome,
										[OutcomePassing] = @OutcomePassing,
										[OutcomeFilePath] = @OutcomeFilePath,
										[MachineName] = @MachineName,
										[RunBy] = @RunBy,
										[Description] = @Description,
										[Dump] = @Dump,
										[ProductId] = @ProductId,
										[SensorId] = @SensorId,
										[MeasValue] = @MeasValue,
										[MaxValue] = @MaxValue,
										[MinValue] = @MinValue,
										[Notes] = @Notes,
										[ErrorMessage] = @ErrorMessage,
										[StartTime] = @StartTime,
										[EndTime] = @EndTime,
										[DateCreated] = @DateCreated
								WHERE	[HistogramId] = @HistogramId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@HistogramId", SqlDbType.Int, 4).Value = HistogramId;
					cmd.Parameters.Add("@ReportsTo", SqlDbType.Int, 4).Value = ReportsTo == null ? (Object)DBNull.Value : ReportsTo;
					cmd.Parameters.Add("@RunID", SqlDbType.UniqueIdentifier).Value = RunID == null ? (Object)DBNull.Value : RunID;
					cmd.Parameters.Add("@RunStepNum", SqlDbType.Int, 4).Value = RunStepNum == null ? (Object)DBNull.Value : RunStepNum;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = Name;
					cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = Status;
					cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = Type == null ? (Object)DBNull.Value : Type;
					cmd.Parameters.Add("@Build", SqlDbType.NVarChar, 50).Value = Build == null ? (Object)DBNull.Value : Build;
					cmd.Parameters.Add("@Platform", SqlDbType.NVarChar, 50).Value = Platform == null ? (Object)DBNull.Value : Platform;
					cmd.Parameters.Add("@Category", SqlDbType.NVarChar, 50).Value = Category == null ? (Object)DBNull.Value : Category;
					cmd.Parameters.Add("@Process", SqlDbType.NVarChar, 50).Value = Process == null ? (Object)DBNull.Value : Process;
					cmd.Parameters.Add("@Outcome", SqlDbType.NVarChar, 50).Value = Outcome == null ? (Object)DBNull.Value : Outcome;
					cmd.Parameters.Add("@OutcomePassing", SqlDbType.Bit, 1).Value = OutcomePassing;
					cmd.Parameters.Add("@OutcomeFilePath", SqlDbType.NVarChar, 500).Value = OutcomeFilePath == null ? (Object)DBNull.Value : OutcomeFilePath;
					cmd.Parameters.Add("@MachineName", SqlDbType.NVarChar, 50).Value = MachineName == null ? (Object)DBNull.Value : MachineName;
					cmd.Parameters.Add("@RunBy", SqlDbType.NVarChar, 50).Value = RunBy == null ? (Object)DBNull.Value : RunBy;
					cmd.Parameters.Add("@Description", SqlDbType.NVarChar, -1).Value = Description == null ? (Object)DBNull.Value : Description;
					cmd.Parameters.Add("@Dump", SqlDbType.NVarChar, -1).Value = Dump == null ? (Object)DBNull.Value : Dump;
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = ProductId;
					cmd.Parameters.Add("@SensorId", SqlDbType.Int, 4).Value = SensorId == null ? (Object)DBNull.Value : SensorId;
					cmd.Parameters.Add("@MeasValue", SqlDbType.Decimal).Value = MeasValue == null ? (Object)DBNull.Value : MeasValue;
					cmd.Parameters.Add("@MaxValue", SqlDbType.Decimal).Value = MaxValue == null ? (Object)DBNull.Value : MaxValue;
					cmd.Parameters.Add("@MinValue", SqlDbType.Decimal).Value = MinValue == null ? (Object)DBNull.Value : MinValue;
					cmd.Parameters.Add("@Notes", SqlDbType.NVarChar, -1).Value = Notes == null ? (Object)DBNull.Value : Notes;
					cmd.Parameters.Add("@ErrorMessage", SqlDbType.NVarChar, -1).Value = ErrorMessage == null ? (Object)DBNull.Value : ErrorMessage;
					cmd.Parameters.Add("@StartTime", SqlDbType.DateTime, 8).Value = StartTime;
					cmd.Parameters.Add("@EndTime", SqlDbType.DateTime, 8).Value = EndTime;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
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
		public static async Task Delete(int histogramId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"DELETE	FROM [Histogram]
								WHERE	[HistogramId] = @HistogramId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@HistogramId", SqlDbType.Int, 4).Value = histogramId;
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
		public static async Task<Histogram> Get(int histogramId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[HistogramId],
										[ReportsTo],
										[RunID],
										[RunStepNum],
										[Name],
										[Status],
										[Type],
										[Build],
										[Platform],
										[Category],
										[Process],
										[Outcome],
										[OutcomePassing],
										[OutcomeFilePath],
										[MachineName],
										[RunBy],
										[Description],
										[Dump],
										[ProductId],
										[SensorId],
										[MeasValue],
										[MaxValue],
										[MinValue],
										[Notes],
										[ErrorMessage],
										[StartTime],
										[EndTime],
										[DateCreated]
								FROM	[Histogram]
								WHERE	[HistogramId] = @HistogramId;";

				Histogram histogram = new Histogram();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@HistogramId", SqlDbType.Int, 4).Value = histogramId;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (reader.Read())
						{
							histogram.HistogramId = Convert.ToInt32(reader["HistogramId"]);
							histogram.ReportsTo = reader["ReportsTo"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReportsTo"]);
							histogram.RunID = reader["RunID"] == DBNull.Value ? (Guid?)null : (Guid)reader["RunID"];
							histogram.RunStepNum = reader["RunStepNum"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["RunStepNum"]);
							histogram.Name = reader["Name"].ToString();
							histogram.Status = reader["Status"].ToString();
							histogram.Type = reader["Type"] == DBNull.Value ? null : reader["Type"].ToString();
							histogram.Build = reader["Build"] == DBNull.Value ? null : reader["Build"].ToString();
							histogram.Platform = reader["Platform"] == DBNull.Value ? null : reader["Platform"].ToString();
							histogram.Category = reader["Category"] == DBNull.Value ? null : reader["Category"].ToString();
							histogram.Process = reader["Process"] == DBNull.Value ? null : reader["Process"].ToString();
							histogram.Outcome = reader["Outcome"] == DBNull.Value ? null : reader["Outcome"].ToString();
							histogram.OutcomePassing = Convert.ToBoolean(reader["OutcomePassing"]);
							histogram.OutcomeFilePath = reader["OutcomeFilePath"] == DBNull.Value ? null : reader["OutcomeFilePath"].ToString();
							histogram.MachineName = reader["MachineName"] == DBNull.Value ? null : reader["MachineName"].ToString();
							histogram.RunBy = reader["RunBy"] == DBNull.Value ? null : reader["RunBy"].ToString();
							histogram.Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();
							histogram.Dump = reader["Dump"] == DBNull.Value ? null : reader["Dump"].ToString();
							histogram.ProductId = Convert.ToInt32(reader["ProductId"]);
							histogram.SensorId = reader["SensorId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SensorId"]);
							histogram.MeasValue = reader["MeasValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MeasValue"]);
							histogram.MaxValue = reader["MaxValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MaxValue"]);
							histogram.MinValue = reader["MinValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MinValue"]);
							histogram.Notes = reader["Notes"] == DBNull.Value ? null : reader["Notes"].ToString();
							histogram.ErrorMessage = reader["ErrorMessage"] == DBNull.Value ? null : reader["ErrorMessage"].ToString();
							histogram.StartTime = Convert.ToDateTime(reader["StartTime"]);
							histogram.EndTime = Convert.ToDateTime(reader["EndTime"]);
							histogram.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
						}
					}
				}

				return histogram;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<Histogram>>  GetAll()
		{
            var histogramList = new List<Histogram>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				await con.OpenAsync();

				String sql =  @"SELECT	[HistogramId],
										[ReportsTo],
										[RunID],
										[RunStepNum],
										[Name],
										[Status],
										[Type],
										[Build],
										[Platform],
										[Category],
										[Process],
										[Outcome],
										[OutcomePassing],
										[OutcomeFilePath],
										[MachineName],
										[RunBy],
										[Description],
										[Dump],
										[ProductId],
										[SensorId],
										[MeasValue],
										[MaxValue],
										[MinValue],
										[Notes],
										[ErrorMessage],
										[StartTime],
										[EndTime],
										[DateCreated]
								FROM	[Histogram];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return histogramList;
                        while (await reader.ReadAsync())
                        {
                                var test = new Histogram
                                {
                                    HistogramId = Convert.ToInt32(reader["HistogramId"]),
                                    ReportsTo = reader["ReportsTo"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReportsTo"]),
                                    RunID = reader["RunID"] == DBNull.Value ? (Guid?)null : (Guid)reader["RunID"],
                                    RunStepNum = reader["RunStepNum"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["RunStepNum"]),
                                    Name = reader["Name"].ToString(),
                                    Status = reader["Status"].ToString(),
                                    Type = reader["Type"] == DBNull.Value ? null : reader["Type"].ToString(),
                                    Build = reader["Build"] == DBNull.Value ? null : reader["Build"].ToString(),
                                    Platform = reader["Platform"] == DBNull.Value ? null : reader["Platform"].ToString(),
                                    Category = reader["Category"] == DBNull.Value ? null : reader["Category"].ToString(),
                                    Process = reader["Process"] == DBNull.Value ? null : reader["Process"].ToString(),
                                    Outcome = reader["Outcome"] == DBNull.Value ? null : reader["Outcome"].ToString(),
                                    OutcomePassing = Convert.ToBoolean(reader["OutcomePassing"]),
                                    OutcomeFilePath = reader["OutcomeFilePath"] == DBNull.Value ? null : reader["OutcomeFilePath"].ToString(),
                                    MachineName = reader["MachineName"] == DBNull.Value ? null : reader["MachineName"].ToString(),
                                    RunBy = reader["RunBy"] == DBNull.Value ? null : reader["RunBy"].ToString(),
                                    Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                                    Dump = reader["Dump"] == DBNull.Value ? null : reader["Dump"].ToString(),
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    SensorId = reader["SensorId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["SensorId"]),
                                    MeasValue = reader["MeasValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MeasValue"]),
                                    MaxValue = reader["MaxValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MaxValue"]),
                                    MinValue = reader["MinValue"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["MinValue"]),
                                    Notes = reader["Notes"] == DBNull.Value ? null : reader["Notes"].ToString(),
                                    ErrorMessage = reader["ErrorMessage"] == DBNull.Value ? null : reader["ErrorMessage"].ToString(),
                                    StartTime = Convert.ToDateTime(reader["StartTime"]),
                                    EndTime = Convert.ToDateTime(reader["EndTime"]),
                                    DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                            };
                            histogramList.Add(test);
                        }
                    }
				}
				return histogramList;
			}
		}
		#endregion
	}
}