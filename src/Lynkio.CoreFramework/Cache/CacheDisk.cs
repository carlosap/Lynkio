using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Lynkio.CoreFramework.Extensions;

namespace Lynkio.CoreFramework.Cache
{
    public static class CacheDisk
    {
        private static string _directory;
        private static int _maxSizeInMb;
        public static string FilePath = string.Empty;
        private static Task Initialise()
        {
            return Task.Run(() => {
                _maxSizeInMb = Config.Cache.Disk.MaxSizeInMb;          
                _directory = Path.Combine(Config.AppPath, "DataSource", "cache");
                Directory.CreateDirectory(_directory);
            });
        }
        public static Task Set(string key, object value) => Set(key, value, null);
        public static Task Set(string key, object value, TimeSpan validFor) => 
            Set(key, value, DateTime.UtcNow.Add(validFor));
        public static Task Set(string key, object value, DateTime expiresAt) => 
            Set(key, value, expiresAt);
        public static Task Set(string key, object value, DateTime? expiresAt)
        {
            return Task.Run(async () => {
                try
                {
                    await Initialise();
                    if (await HasExceededQuota()) return;
                    var cachePath = GetFilePath(key);
                    if (File.Exists(await cachePath))
                        File.Delete(await cachePath);

                    var fileName = await GetFileNameSearchPattern(key);
                    var existingCaches = Directory.EnumerateFiles(_directory, fileName);
                    foreach (
                        var existingCache in
                            existingCaches.Where(existingCache => _directory != null)
                                .Where(existingCache => _directory != null))
                        File.Delete(Path.Combine(_directory, existingCache));
                    var newCachePath = await GetFilePath(key, expiresAt);
                    FilePath = newCachePath;
                    string item;
                    if (value.GetType() != typeof(string))
                        item = value.SerializeObject<dynamic>();
                    else
                        item = value as string;

                    if (item == null) return;
                    File.WriteAllText(newCachePath, item);
                }
                catch (Exception ex)
                {
                    Log.Exception("CacheDisk:Set", ex);
                }
            });
        }
        public static Task<string> Get(string key)
        {
            return Task.Run(async () =>  {
                string value = string.Empty;
                try
                {
                    await Initialise();
                    var cachePath = await GetFilePath(key);
                    if (!File.Exists(cachePath))
                    {
                        cachePath = null;
                        var fileName = await GetFileNameSearchPattern(key);
                        if (_directory != null)
                        {
                            var existingCaches = Directory.EnumerateFiles(_directory, fileName)
                                .OrderByDescending(x => x);
                            if (existingCaches.Any())
                            {
                                var mostRecentCache = existingCaches.ElementAt(0);
                                if (mostRecentCache.EndsWith(".expiry"))
                                {
                                    var expiresAt =
                                        mostRecentCache.Substring(
                                            mostRecentCache.IndexOf(".expiry", StringComparison.Ordinal) - 19, 19);
                                    var expiresAtDate = expiresAt.Replace('-', '/').Replace('_', ':');
                                    var expiryDate = DateTime.Parse(expiresAtDate);
                                    if (expiryDate > DateTime.UtcNow)
                                        if (_directory != null) cachePath = Path.Combine(_directory, mostRecentCache);
                                }
                            }
                        }
                    }
                    if (cachePath != null)
                    {
                        value = File.ReadAllText(cachePath);
                    }

                }
                catch (Exception ex)
                {
                    Log.Exception("CacheDisk:Get", ex);
                    value = string.Empty;
                }
                return value ?? string.Empty;
            });
        }

        private static Task<string> GetFilePath(string cacheKey, DateTime? expiresAt)
        {
            return Task.Run(async () => {
                cacheKey = await ReplaceInvalidChars(cacheKey);
                var path = await GetFilePath(cacheKey);
                if (expiresAt.HasValue) path = $"{path}.{expiresAt.Value.ToString("yyyy-MM-ddTHH_mm_ss")}.expiry";
                return path;

            });

        }
        public static Task Remove(string key) => Task.Run(async () => {
            File.Delete(await GetFilePath(key));

        });
        private static Task<string> GetFileName(string cacheKey) => Task.Run(() => {
            return cacheKey + ".cache";
        }); 
        private static Task<string> GetFileNameSearchPattern(string cacheKey) => Task.Run(async () => {
            return GetFileName(await ReplaceInvalidChars(cacheKey)) + ".*";
        });

        private static Task<string> ReplaceInvalidChars(string cacheKey) => Task.Run(async () => {
            return Path.GetInvalidFileNameChars().Aggregate(await ClearInvalidHttpChars(cacheKey), (current, c) => current.Replace(c, '_'));
        });
        private static Task<string> ClearInvalidHttpChars(string cacheKey) => Task.Run(() => {
            return cacheKey.Replace("http", "").Replace("https", "").Replace(":", "").Replace("//", "").Replace("www.", "");
        }); 
        private static Task<string> GetFilePath(string cacheKey) => Task.Run(async () => {
            return Path.Combine(_directory, await GetFileName(await ReplaceInvalidChars(cacheKey)));
        });
        private static Task<long> GetDirectorySize() => Task.Run(() => {
            return new DirectoryInfo(_directory).GetFiles().Sum(x => x.Length);
        }); 
        private static Task<bool> HasExceededQuota() => Task.Run(async () => {
            return await GetDirectorySize() / (1024 * 1024) > _maxSizeInMb;
        });  
    }
}

