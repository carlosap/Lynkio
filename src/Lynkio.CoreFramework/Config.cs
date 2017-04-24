using System;
using System.IO;
using System.Threading.Tasks;

namespace Lynkio.CoreFramework
{
    public static class Config
    {
        public static string AppPath { get; set; } = Directory.GetCurrentDirectory();
        public static string Version { get; set; } = "1.0.1";
        public static string HostingEnvironment { get; set; } = "Development"; //Production;Development,Staging 
        static Config(){}
        public static class Cache
        {
            public static string SensorKey = "sensor:{0}:{1}";
            public static string ProductKey = "product:{0}";
            public static string DataSourceKey = "datasource:{0}";
            public static class Disk
            {
                public static readonly int MaxSizeInMb = 300;
                public static readonly bool Enable = true;
                public static readonly bool EnableEncryption = false;
                public static readonly string DevDirectory = "DataSource";
                public static readonly string StagingDirectory = "c:\\temp\\DiskCache";
                public static readonly string Directory = "D:\\home\\LogFiles\\DiskCache";
            }
            public static class Memory
            {
                public static readonly bool Enable = true;
            }
        }
        public static class DataServer
        {
            public static class SqlServerConnection
            {
                public static readonly string DevConnectionString = "Data Source=.;Initial Catalog=PMT;Integrated Security=True";
                public static readonly string StagingConnectionString = "Data Source=.;Initial Catalog=PMT;Integrated Security=True";
                public static readonly string ConnectionString = "Server=tcp:spartanjs.database.windows.net,1433;Database=EJPARSE;User ID=cperez@spartanjs;Password=Man6576tilla1;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                public static readonly int TimeOut = 20;
                public static async Task<int> GetTimeOut() => await Task.Run(() => TimeOut);
                public static async Task<string> GetConnectionString()
                {
                    return await Task.Run(() =>
                    {
                        string results = string.Empty;
                        try
                        {
                            string strEnv = HostingEnvironment;
                            switch (strEnv)
                            {
                                case "Development":
                                    results = DevConnectionString;
                                    break;
                                case "Staging":
                                    results = StagingConnectionString;
                                    break;
                                default:
                                    results = ConnectionString;
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Exception("SqlServer:GetConnectionString", ex);
                        }
                        return results;
                    });
                }

            }
            public static class MySqlServerConnection
            {
                public static readonly string DevConnectionString = "";
                public static readonly string StagingConnectionString = "";
                public static readonly string ConnectionString = "";
                public static readonly int TimeOut = 20;
            }
        }
        public static class Email
        {
            public static class SendGrid
            {
                public static readonly bool Enabled = false;
                public static readonly string ApiKey = "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";
                public static readonly string FromName = "Sentech Systems";
                public static readonly string From = "lynkio@donotreply.com";
                public static readonly string Subject = "Sensor Notifications";
            }
        }

    }
}
