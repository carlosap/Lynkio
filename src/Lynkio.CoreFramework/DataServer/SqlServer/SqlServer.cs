//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Threading.Tasks;
//namespace Lynkio.CoreFramework.DataServer
//{
//    public class SqlServer : IDatabase
//    {
//        public SqlCommand SqlCommand { get; set; }
//        public DatabaseServerType ServerType => DatabaseServerType.SqlServer;
//        public SqlServer() { Initialise(); }
//        public Task Initialise() => Task.Run(() =>
//        {
//            SqlCommand = new SqlCommand();
//        });
//        public Task<string> usp_Exec(string storeProc, Dictionary<string, object> parameters)
//        {
//            return Task.Run(async () =>
//            {
//                var results = string.Empty;
//                try
//                {
//                    using (var con = new SqlConnection(await Config.DataServer.SqlServerConnection.GetConnectionString()))
//                    {
//                        await con.OpenAsync();
//                        using (var command = new SqlCommand(storeProc, con))
//                        {
//                            command.CommandType = CommandType.StoredProcedure;
//                            command.CommandText = storeProc;
//                            command.CommandTimeout = await Config.DataServer.SqlServerConnection.GetTimeOut();
//                            if (parameters.Count > 0)
//                                foreach (var param in parameters)
//                                    command.Parameters.AddWithValue(param.Key, param.Value);
//                            await command.ExecuteReaderAsync();
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Log.Exception("SqlServer:usp_Exec", ex);
//                }
//                finally
//                {
//                    SqlCommand.Dispose();
//                }
//                return results;
//            });
//        }
//    }
//}

