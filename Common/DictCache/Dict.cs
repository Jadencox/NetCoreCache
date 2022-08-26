using Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DictCache
{
    public abstract class Dict<T> : IDict<T>
    {
        private string CacheKey;

        /// <summary>
        /// Gets or sets granularity for cache.
        /// </summary>
        //protected DictCacheMode CacheMode { get; private set; }

        /// <summary>
        /// Gets or sets the instance of <see ref="ICache"/> for code table.
        /// </summary>
        protected ICache Cache { get; private set; }

        /// <summary>
        /// Initialize a new <see cref="CodeTableProvider"/>.
        /// </summary>
        /// <param name="cacheFactory">The <see cref="ICacheFactory"/> instance to create a cache service.</param>
        public Dict(ICacheFactory cacheFactory)
        {
            CacheKey = $"{typeof(T).FullName}";
            var cacheOptions = new CacheOptions();
            Cache = cacheFactory.GetCache("DoCare_Caching_Dict", cacheOptions);
        }

        /// <summary>
        /// Gets all data by key
        /// </summary>
        /// <returns>A list of category names.</returns>
        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> data;
            if (!Cache.TryGet(CacheKey, out data))
            {
                data = GetAllData();
                Cache.Set(CacheKey, data);
            }
            return data;
        }

        /// <summary>
        /// Remove cache by the Key
        /// </summary>
        public void Remove()
        {
            Cache.Remove(CacheKey);
        }

        /// <summary>
        /// Clear all catch from the cache name
        /// </summary>
        public void Clear()
        {
            Cache.Clear();
        }

        /// <summary>
        /// Gets all category names.
        /// </summary>
        /// <returns>A list of category names.</returns>
        protected abstract IEnumerable<T> GetAllData();
    }
}
