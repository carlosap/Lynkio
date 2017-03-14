using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
namespace Lynkio.CoreFramework.Cache
{
    public static class Memory
    {
        private static IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private static void Set(string key, object value, MemoryCacheEntryOptions options) => _cache.Set(key, value, options);
        public static Task<T> Get<T>(string key)
        {
            return Task.Run(() =>
            {
                var results = _cache.Get<T>(key);
                return results;
            });
        }

        // Stays in the cache as long as possible
        public static Task Set(string key, object value)
        {
            return Task.Run(() =>
            {
                var options = new MemoryCacheEntryOptions().SetPriority(CacheItemPriority.NeverRemove);
                Set(key, value, options);
            });
        }
        //// Automatically remove at a certain time
        /// SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddDays(2)));
        public static Task SetAndExpiresDays(string key, object value, int days = 1)
        {
            return Task.Run(() =>
            {
                var options = new MemoryCacheEntryOptions();
                options.SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddDays(days));
                Set(key, value, options);
            });

        }

        public static Task SetAndExpiresMinutes(string key, object value, int minutes = 1)
        {
            return Task.Run(() =>
            {
                var options = new MemoryCacheEntryOptions();
                options.SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddMinutes(minutes));
                Set(key, value, options);
            });

        }

        public static Task SetAndExpiresSeconds(string key, object value, int seconds = 30)
        {
            return Task.Run(() =>
            {
                var options = new MemoryCacheEntryOptions();
                options.SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddSeconds(seconds));
                Set(key, value, options);
            });

        }

        public static Task SetAndExpiresMonths(string key, object value, int months = 1)
        {
            return Task.Run(() =>
            {
                var options = new MemoryCacheEntryOptions();
                options.SetAbsoluteExpiration(DateTimeOffset.UtcNow.AddMonths(months));
                Set(key, value, options);
            });

        }
        // Automatically remove if not accessed in the given time
        //SetSlidingExpiration(TimeSpan.FromMinutes(5)));
        public static Task SetAndValidFor(string key, object value, System.TimeSpan validFor)
        {
            return Task.Run(() =>
            {
                var options = new MemoryCacheEntryOptions();
                options.SetSlidingExpiration(validFor);
                Set(key, value, options);
            });
        }
        public static Task Remove(string key)
        {
            return Task.Run(() =>
            {
                _cache.Remove(key);
            });
        }
    }
}

