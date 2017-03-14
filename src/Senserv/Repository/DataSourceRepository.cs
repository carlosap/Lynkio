using System;
using System.IO;
using System.Threading.Tasks;
using Lynkio.CoreFramework;
using Lynkio.CoreFramework.Cache;
using Lynkio.CoreFramework.Extensions;
using Senserv.Interfaces;

namespace Senserv.Repository
{
    public class DataSourceRepository:IDataSource
    {
        public Task<object> Get(string name, string cache)
        {
            return Task.Run(async () =>
            {
                var cachekey = string.Format(Config.Cache.DataSourceKey, name);
                var isCache = Convert.ToBoolean(string.IsNullOrWhiteSpace(cache) ? "true" : "false");
                if (!isCache) await Memory.Remove(cachekey);
                var results = await Memory.Get<object>(cachekey);
                if (results != null) return results;
                results = GetFileDataSource(name);
                await Memory.SetAndExpiresDays(cachekey, results, 1);
                return results;
            });
        }

        private static object GetFileDataSource(string name)
        {
            object results = null;
            var directoryPath = Path.Combine(Config.AppPath, "DataSource");
            var fileName = Path.Combine(directoryPath, name + ".js");
            if (File.Exists(fileName))
                results = fileName.LoadAsTypeAsync<object>();

            return results;
        }
    }
}
