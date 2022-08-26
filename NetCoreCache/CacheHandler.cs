using Cache;
using CoreCache;
using NetCoreCache;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCache
{
    public class CacheHandler
    {
        public static IServiceProvider ServiceProvider1 { get; private set; }

        /// <summary>
        /// Get Cache
        /// </summary>
        /// <param name="cacheName"></param>
        /// <param name="cacheOptions"></param>
        /// <returns></returns>
        public static ICache GetCache(CacheNameConstants cacheName = CacheNameConstants.DoCare_Caching_Default, CacheOptions cacheOptions = null)
        {
            if (null == cacheOptions)
            {
                cacheOptions = new CacheOptions();
            }
            //return HttpHelper.HttpContext.RequestServices.GetService<ICacheFactory>().GetCache(cacheName.ToString(), cacheOptions);
            return ServiceProviderHelper.ServiceProvider1.GetService<ICacheFactory>().GetCache(cacheName.ToString(), cacheOptions);
        }

        /// <summary>
        /// get cache value by key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="cacheName"></param>
        /// <returns></returns>
        public static T TryGet<T>(CacheKeyConstants key, CacheNameConstants cacheName = CacheNameConstants.DoCare_Caching_Default)
        {
            var cache = GetCache(cacheName);
            if (cache.TryGet(key.ToString(), out object value))
            {
                // var valueT = (T)value;
                var valueT = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(value));
                return valueT;
            }

            return default(T);
        }

        /// <summary>
        /// set value to cache with the specified key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheName"></param>
        /// <param name="cacheOptions"></param>
        public static void Set(CacheKeyConstants key, object value, CacheNameConstants cacheName = CacheNameConstants.DoCare_Caching_Default, CacheOptions cacheOptions = null)
        {
            var cache = GetCache(cacheName);
            if (null == cacheOptions)
            {
                cache.Set(key.ToString(), value);
            }
            else
            {
                cache.Set(key.ToString(), value, cacheOptions);
            }
        }

        /// <summary>
        /// Remove the cache item associated with the specified key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cacheName"></param>
        public static void Remove(CacheKeyConstants key, CacheNameConstants cacheName = CacheNameConstants.DoCare_Caching_Default)
        {
            var cache = GetCache(cacheName);
            cache.Remove(key.ToString());
        }
    }
}
