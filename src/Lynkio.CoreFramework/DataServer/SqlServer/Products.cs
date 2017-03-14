using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Lynkio.CoreFramework.DataServer.SqlServer
{
	public class Products
	{
		#region Properties
		public int ProductId { get; set; }
		public int? ReportsTo { get; set; }
		public int? UserId { get; set; }
		public string Name { get; set; }
		public string SerialNumber { get; set; }
		public string ProductNumber { get; set; }
		public string AssemblyNumber { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public string ProductVersion { get; set; }
		public string ProductValue { get; set; }
		public string Author { get; set; }
		public string Lic { get; set; }
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
				String sql =  @"INSERT INTO [Products]
								(
									[ReportsTo],
									[UserId],
									[Name],
									[SerialNumber],
									[ProductNumber],
									[AssemblyNumber],
									[Make],
									[Model],
									[ProductVersion],
									[ProductValue],
									[Author],
									[Lic]
								)
								VALUES
								(
									@ReportsTo,
									@UserId,
									@Name,
									@SerialNumber,
									@ProductNumber,
									@AssemblyNumber,
									@Make,
									@Model,
									@ProductVersion,
									@ProductValue,
									@Author,
									@Lic
								);";

				sql += "SELECT SCOPE_IDENTITY();";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@ReportsTo", SqlDbType.Int, 4).Value = ReportsTo == null ? (Object)DBNull.Value : ReportsTo;
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId == null ? (Object)DBNull.Value : UserId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar, 256).Value = SerialNumber == null ? (Object)DBNull.Value : SerialNumber;
					cmd.Parameters.Add("@ProductNumber", SqlDbType.NVarChar, 256).Value = ProductNumber == null ? (Object)DBNull.Value : ProductNumber;
					cmd.Parameters.Add("@AssemblyNumber", SqlDbType.NVarChar, 256).Value = AssemblyNumber == null ? (Object)DBNull.Value : AssemblyNumber;
					cmd.Parameters.Add("@Make", SqlDbType.NVarChar, 256).Value = Make == null ? (Object)DBNull.Value : Make;
					cmd.Parameters.Add("@Model", SqlDbType.NVarChar, 256).Value = Model == null ? (Object)DBNull.Value : Model;
					cmd.Parameters.Add("@ProductVersion", SqlDbType.NVarChar, 256).Value = ProductVersion == null ? (Object)DBNull.Value : ProductVersion;
					cmd.Parameters.Add("@ProductValue", SqlDbType.NVarChar, 256).Value = ProductValue == null ? (Object)DBNull.Value : ProductValue;
					cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 256).Value = Author == null ? (Object)DBNull.Value : Author;
					cmd.Parameters.Add("@Lic", SqlDbType.NVarChar, 256).Value = Lic == null ? (Object)DBNull.Value : Lic;

					// Execute the insert statement and get value of the identity column.
					ProductId = Convert.ToInt32(cmd.ExecuteScalarAsync());
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
				String sql =  @"UPDATE	[Products]
								SET		[ReportsTo] = @ReportsTo,
										[UserId] = @UserId,
										[Name] = @Name,
										[SerialNumber] = @SerialNumber,
										[ProductNumber] = @ProductNumber,
										[AssemblyNumber] = @AssemblyNumber,
										[Make] = @Make,
										[Model] = @Model,
										[ProductVersion] = @ProductVersion,
										[ProductValue] = @ProductValue,
										[Author] = @Author,
										[Lic] = @Lic
								WHERE	[ProductId] = @ProductId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = ProductId;
					cmd.Parameters.Add("@ReportsTo", SqlDbType.Int, 4).Value = ReportsTo == null ? (Object)DBNull.Value : ReportsTo;
					cmd.Parameters.Add("@UserId", SqlDbType.Int, 4).Value = UserId == null ? (Object)DBNull.Value : UserId;
					cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 256).Value = Name == null ? (Object)DBNull.Value : Name;
					cmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar, 256).Value = SerialNumber == null ? (Object)DBNull.Value : SerialNumber;
					cmd.Parameters.Add("@ProductNumber", SqlDbType.NVarChar, 256).Value = ProductNumber == null ? (Object)DBNull.Value : ProductNumber;
					cmd.Parameters.Add("@AssemblyNumber", SqlDbType.NVarChar, 256).Value = AssemblyNumber == null ? (Object)DBNull.Value : AssemblyNumber;
					cmd.Parameters.Add("@Make", SqlDbType.NVarChar, 256).Value = Make == null ? (Object)DBNull.Value : Make;
					cmd.Parameters.Add("@Model", SqlDbType.NVarChar, 256).Value = Model == null ? (Object)DBNull.Value : Model;
					cmd.Parameters.Add("@ProductVersion", SqlDbType.NVarChar, 256).Value = ProductVersion == null ? (Object)DBNull.Value : ProductVersion;
					cmd.Parameters.Add("@ProductValue", SqlDbType.NVarChar, 256).Value = ProductValue == null ? (Object)DBNull.Value : ProductValue;
					cmd.Parameters.Add("@Author", SqlDbType.NVarChar, 256).Value = Author == null ? (Object)DBNull.Value : Author;
					cmd.Parameters.Add("@Lic", SqlDbType.NVarChar, 256).Value = Lic == null ? (Object)DBNull.Value : Lic;
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
		public static async Task Delete(int productId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"DELETE	FROM [Products]
								WHERE	[ProductId] = @ProductId;";

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = productId;
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
		public static async Task<Products> Get(int productId)
		{
			var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				String sql =  @"SELECT	[ProductId],
										[ReportsTo],
										[UserId],
										[Name],
										[SerialNumber],
										[ProductNumber],
										[AssemblyNumber],
										[Make],
										[Model],
										[ProductVersion],
										[ProductValue],
										[Author],
										[Lic]
								FROM	[Products]
								WHERE	[ProductId] = @ProductId;";

				Products products = new Products();

				await con.OpenAsync();

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					cmd.Parameters.Add("@ProductId", SqlDbType.Int, 4).Value = productId;

					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
						if (await reader.ReadAsync())
						{
							products.ProductId = Convert.ToInt32(reader["ProductId"]);
							products.ReportsTo = reader["ReportsTo"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReportsTo"]);
							products.UserId = reader["UserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UserId"]);
							products.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
							products.SerialNumber = reader["SerialNumber"] == DBNull.Value ? null : reader["SerialNumber"].ToString();
							products.ProductNumber = reader["ProductNumber"] == DBNull.Value ? null : reader["ProductNumber"].ToString();
							products.AssemblyNumber = reader["AssemblyNumber"] == DBNull.Value ? null : reader["AssemblyNumber"].ToString();
							products.Make = reader["Make"] == DBNull.Value ? null : reader["Make"].ToString();
							products.Model = reader["Model"] == DBNull.Value ? null : reader["Model"].ToString();
							products.ProductVersion = reader["ProductVersion"] == DBNull.Value ? null : reader["ProductVersion"].ToString();
							products.ProductValue = reader["ProductValue"] == DBNull.Value ? null : reader["ProductValue"].ToString();
							products.Author = reader["Author"] == DBNull.Value ? null : reader["Author"].ToString();
							products.Lic = reader["Lic"] == DBNull.Value ? null : reader["Lic"].ToString();
						}
					}
				}

				return products;
			}
		}
		#endregion

		#region GetAll
		/// <summary>
		/// Gets all records.
		/// </summary>
		public static async Task<List<Products>> GetAll()
		{
            var products = new List<Products>();
            var connectionString = await Config.DataServer.SqlServerConnection.GetConnectionString();

			using (SqlConnection con = new SqlConnection(connectionString))
			{
				await con.OpenAsync();

				String sql =  @"SELECT	[ProductId],
										[ReportsTo],
										[UserId],
										[Name],
										[SerialNumber],
										[ProductNumber],
										[AssemblyNumber],
										[Make],
										[Model],
										[ProductVersion],
										[ProductValue],
										[Author],
										[Lic]
								FROM	[Products];";

				using (SqlCommand cmd = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
					{
                        if (!reader.HasRows) return products;
                        while (await reader.ReadAsync())
                        {
                            var product = new Products
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ReportsTo = reader["ReportsTo"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["ReportsTo"]),
                                UserId = reader["UserId"] == DBNull.Value ? (int?)null : Convert.ToInt32(reader["UserId"]),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                SerialNumber = reader["SerialNumber"] == DBNull.Value ? null : reader["SerialNumber"].ToString(),
                                ProductNumber = reader["ProductNumber"] == DBNull.Value ? null : reader["ProductNumber"].ToString(),
                                AssemblyNumber = reader["AssemblyNumber"] == DBNull.Value ? null : reader["AssemblyNumber"].ToString(),
                                Make = reader["Make"] == DBNull.Value ? null : reader["Make"].ToString(),
                                Model = reader["Model"] == DBNull.Value ? null : reader["Model"].ToString(),
                                ProductVersion = reader["ProductVersion"] == DBNull.Value ? null : reader["ProductVersion"].ToString(),
                                ProductValue = reader["ProductValue"] == DBNull.Value ? null : reader["ProductValue"].ToString(),
                                Author = reader["Author"] == DBNull.Value ? null : reader["Author"].ToString(),
                                Lic = reader["Lic"] == DBNull.Value ? null : reader["Lic"].ToString()
                        };
                            products.Add(product);
                        }
                    }
				}

				return products;
			}
		}
		#endregion
	}
}