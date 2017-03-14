using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class Users
	{
		#region Properties
		public int UserId { get; set; }
		public int? ReportsTo { get; set; }
		public string UserName { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool EmailNotification { get; set; }
		public bool EmailConfirmed { get; set; }
		public string PasswordHash { get; set; }
		public string SecurityStamp { get; set; }
		public string Phone { get; set; }
		public bool TextNotification { get; set; }
		public bool PhoneConfirmed { get; set; }
		public bool TwoFactorEnabled { get; set; }
		public bool LockEnabled { get; set; }
		public DateTime? LockEndDateUtc { get; set; }
		public int AccessFailedCount { get; set; }
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
                string sql =  @"INSERT INTO [Users]
								(
									[ReportsTo],
									[UserName],
									[Name],
									[LastName],
									[Email],
									[EmailNotification],
									[EmailConfirmed],
									[PasswordHash],
									[SecurityStamp],
									[Phone],
									[TextNotification],
									[PhoneConfirmed],
									[TwoFactorEnabled],
									[LockEnabled],
									[LockEndDateUtc],
									[AccessFailedCount],
									[DateCreated],
									[LastUpdate]
								)
								VALUES
								(
									@ReportsTo,
									@UserName,
									@Name,
									@LastName,
									@Email,
									@EmailNotification,
									@EmailConfirmed,
									@PasswordHash,
									@SecurityStamp,
									@Phone,
									@TextNotification,
									@PhoneConfirmed,
									@TwoFactorEnabled,
									@LockEnabled,
									@LockEndDateUtc,
									@AccessFailedCount,
									@DateCreated,
									@LastUpdate
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@ReportsTo", SqlDbType.Int, 4).Value = ReportsTo == null ? (Object)DBNull.Value : ReportsTo;
					cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 256).Value = UserName == null ? (Object)DBNull.Value : UserName;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 256).Value = LastName == null ? (Object)DBNull.Value : LastName;
					cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 256).Value = Email == null ? (Object)DBNull.Value : Email;
					cmd.Parameters.Add("@EmailNotification", SqlDbType.Bit, 1).Value = EmailNotification;
					cmd.Parameters.Add("@EmailConfirmed", SqlDbType.Bit, 1).Value = EmailConfirmed;
					cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, -1).Value = PasswordHash == null ? (Object)DBNull.Value : PasswordHash;
					cmd.Parameters.Add("@SecurityStamp", SqlDbType.NVarChar, -1).Value = SecurityStamp == null ? (Object)DBNull.Value : SecurityStamp;
					cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, -1).Value = Phone == null ? (Object)DBNull.Value : Phone;
					cmd.Parameters.Add("@TextNotification", SqlDbType.Bit, 1).Value = TextNotification;
					cmd.Parameters.Add("@PhoneConfirmed", SqlDbType.Bit, 1).Value = PhoneConfirmed;
					cmd.Parameters.Add("@TwoFactorEnabled", SqlDbType.Bit, 1).Value = TwoFactorEnabled;
					cmd.Parameters.Add("@LockEnabled", SqlDbType.Bit, 1).Value = LockEnabled;
					cmd.Parameters.Add("@LockEndDateUtc", SqlDbType.DateTime, 8).Value = LockEndDateUtc == null ? (Object)DBNull.Value : LockEndDateUtc;
					cmd.Parameters.Add("@AccessFailedCount", SqlDbType.Int, 4).Value = AccessFailedCount;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
					cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;

					// Execute the insert statement and get value of the identity column.
					UserId = Convert.ToInt32(cmd.ExecuteScalarAsync());
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
				String sql =  @"UPDATE	[Users]
								SET		[ReportsTo] = @ReportsTo,
										[UserName] = @UserName,
										[Name] = @Name,
										[LastName] = @LastName,
										[Email] = @Email,
										[EmailNotification] = @EmailNotification,
										[EmailConfirmed] = @EmailConfirmed,
										[PasswordHash] = @PasswordHash,
										[SecurityStamp] = @SecurityStamp,
										[Phone] = @Phone,
										[TextNotification] = @TextNotification,
										[PhoneConfirmed] = @PhoneConfirmed,
										[TwoFactorEnabled] = @TwoFactorEnabled,
										[LockEnabled] = @LockEnabled,
										[LockEndDateUtc] = @LockEndDateUtc,
										[AccessFailedCount] = @AccessFailedCount,
										[DateCreated] = @DateCreated,
										[LastUpdate] = @LastUpdate
								WHERE	[UserId] = @UserId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId;
					cmd.Parameters.Add("@ReportsTo", SqlDbType.Int, 4).Value = ReportsTo == null ? (Object)DBNull.Value : ReportsTo;
					cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 256).Value = UserName == null ? (Object)DBNull.Value : UserName;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 256).Value = LastName == null ? (Object)DBNull.Value : LastName;
					cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 256).Value = Email == null ? (Object)DBNull.Value : Email;
					cmd.Parameters.Add("@EmailNotification", SqlDbType.Bit, 1).Value = EmailNotification;
					cmd.Parameters.Add("@EmailConfirmed", SqlDbType.Bit, 1).Value = EmailConfirmed;
					cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, -1).Value = PasswordHash == null ? (Object)DBNull.Value : PasswordHash;
					cmd.Parameters.Add("@SecurityStamp", SqlDbType.NVarChar, -1).Value = SecurityStamp == null ? (Object)DBNull.Value : SecurityStamp;
					cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, -1).Value = Phone == null ? (Object)DBNull.Value : Phone;
					cmd.Parameters.Add("@TextNotification", SqlDbType.Bit, 1).Value = TextNotification;
					cmd.Parameters.Add("@PhoneConfirmed", SqlDbType.Bit, 1).Value = PhoneConfirmed;
					cmd.Parameters.Add("@TwoFactorEnabled", SqlDbType.Bit, 1).Value = TwoFactorEnabled;
					cmd.Parameters.Add("@LockEnabled", SqlDbType.Bit, 1).Value = LockEnabled;
					cmd.Parameters.Add("@LockEndDateUtc", SqlDbType.DateTime, 8).Value = LockEndDateUtc == null ? (Object)DBNull.Value : LockEndDateUtc;
					cmd.Parameters.Add("@AccessFailedCount", SqlDbType.Int, 4).Value = AccessFailedCount;
					cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime, 8).Value = DateCreated;
					cmd.Parameters.Add("@LastUpdate", SqlDbType.DateTime, 8).Value = LastUpdate;
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
		public static async Task Delete(int userId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"DELETE	FROM [Users]
								WHERE	[UserId] = @UserId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userId;
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
		public static async Task<Users> Get(int userId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[UserId],
										[ReportsTo],
										[UserName],
										[Name],
										[LastName],
										[Email],
										[EmailNotification],
										[EmailConfirmed],
										[PasswordHash],
										[SecurityStamp],
										[Phone],
										[TextNotification],
										[PhoneConfirmed],
										[TwoFactorEnabled],
										[LockEnabled],
										[LockEndDateUtc],
										[AccessFailedCount],
										[DateCreated],
										[LastUpdate]
								FROM	[Users]
								WHERE	[UserId] = @UserId;";

				Users users = new Users();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = userId;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							users.UserId = Convert.ToInt32(reader["UserId"]);
							users.ReportsTo = reader["ReportsTo"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReportsTo"]);
							users.UserName = reader["UserName"] == DBNull.Value ? null : reader["UserName"].ToString();
							users.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
							users.LastName = reader["LastName"] == DBNull.Value ? null : reader["LastName"].ToString();
							users.Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString();
							users.EmailNotification = Convert.ToBoolean(reader["EmailNotification"]);
							users.EmailConfirmed = Convert.ToBoolean(reader["EmailConfirmed"]);
							users.PasswordHash = reader["PasswordHash"] == DBNull.Value ? null : reader["PasswordHash"].ToString();
							users.SecurityStamp = reader["SecurityStamp"] == DBNull.Value ? null : reader["SecurityStamp"].ToString();
							users.Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString();
							users.TextNotification = Convert.ToBoolean(reader["TextNotification"]);
							users.PhoneConfirmed = Convert.ToBoolean(reader["PhoneConfirmed"]);
							users.TwoFactorEnabled = Convert.ToBoolean(reader["TwoFactorEnabled"]);
							users.LockEnabled = Convert.ToBoolean(reader["LockEnabled"]);
							users.LockEndDateUtc = reader["LockEndDateUtc"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LockEndDateUtc"]);
							users.AccessFailedCount = Convert.ToInt32(reader["AccessFailedCount"]);
							users.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
							users.LastUpdate = Convert.ToDateTime(reader["LastUpdate"]);
						}
					}
				}

				return users;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<Users>> GetAll()
		{
            var users = new List<Users>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();
			using (SqlConnection con = new SqlConnection(connectionString))
			{
				await con.OpenAsync();
				var sql =  @"SELECT	[UserId],
										[ReportsTo],
										[UserName],
										[Name],
										[LastName],
										[Email],
										[EmailNotification],
										[EmailConfirmed],
										[PasswordHash],
										[SecurityStamp],
										[Phone],
										[TextNotification],
										[PhoneConfirmed],
										[TwoFactorEnabled],
										[LockEnabled],
										[LockEndDateUtc],
										[AccessFailedCount],
										[DateCreated],
										[LastUpdate]
								FROM	[Users];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return users;
                        while (await reader.ReadAsync())
                        {
                            var user = new Users
                            {
                                UserId = Convert.ToInt32(reader["UserId"]),
                                ReportsTo = reader["ReportsTo"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReportsTo"]),
                                UserName = reader["UserName"] == DBNull.Value ? null : reader["UserName"].ToString(),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                LastName = reader["LastName"] == DBNull.Value ? null : reader["LastName"].ToString(),
                                Email = reader["Email"] == DBNull.Value ? null : reader["Email"].ToString(),
                                EmailNotification = Convert.ToBoolean(reader["EmailNotification"]),
                                EmailConfirmed = Convert.ToBoolean(reader["EmailConfirmed"]),
                                PasswordHash = reader["PasswordHash"] == DBNull.Value ? null : reader["PasswordHash"].ToString(),
                                SecurityStamp = reader["SecurityStamp"] == DBNull.Value ? null : reader["SecurityStamp"].ToString(),
                                Phone = reader["Phone"] == DBNull.Value ? null : reader["Phone"].ToString(),
                                TextNotification = Convert.ToBoolean(reader["TextNotification"]),
                                PhoneConfirmed = Convert.ToBoolean(reader["PhoneConfirmed"]),
                                TwoFactorEnabled = Convert.ToBoolean(reader["TwoFactorEnabled"]),
                                LockEnabled = Convert.ToBoolean(reader["LockEnabled"]),
                                LockEndDateUtc = reader["LockEndDateUtc"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LockEndDateUtc"]),
                                AccessFailedCount = Convert.ToInt32(reader["AccessFailedCount"]),
                                DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                                LastUpdate = Convert.ToDateTime(reader["LastUpdate"])
                            };
                            users.Add(user);
                        }
                    }
				}

				return users;
			}
		}
		#endregion
	}
}