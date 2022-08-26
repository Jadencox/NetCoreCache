using Microsoft.Extensions.Caching.Memory;

namespace Cache
{
    /// <summary>
    /// Represents a local in-memory cache whose values are not serialized.
    /// </summary>
    public class MemoryCache : Cache
    {
        private readonly IMemoryCache cache;
        private MemoryCacheEntryOptions memoryCacheEntryOptions;

        /// <summary>
        /// Initialize a new memory cache.
        /// </summary>
        /// <param name="cache">The inner memory cache to store cache item.</param>
        /// <param name="name">The name of cache.</param>
        /// <param name="options">The cache options applied to created cache.</param>
        public MemoryCache(IMemoryCache cache, string name, CacheOptions options) : base(name, options)
        {
            this.cache = cache;
            memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = options.AbsoluteExpiration,
                AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
                Priority = (Microsoft.Extensions.Caching.Memory.CacheItemPriority)((int)options.Priority),
                SlidingExpiration = options.SlidingExpiration
            };
        }

        /// <summary>
        /// Remove the cache item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of cache item to remove.</param>
        protected override void RemoveCore(string key)
        {
            cache.Remove(key);
        }

        /// <summary>
        /// Set (add or update) a cache item using specified key and value.
        /// </summary>
        /// <param name="key">The key of cache item to set.</param>
        /// <param name="value">The value of cache item to set.</param>
        protected override void SetCore(string key, object value)
        {
            using (ICacheEntry entry = cache.CreateEntry(key))
            {
                entry.SetOptions(memoryCacheEntryOptions);
                entry.Value = value;
            }
        }

        /// <summary>
        /// Set (add or update) a cache item using specified key and value.
        /// </summary>
        /// <param name="key">The key of cache item to set.</param>
        /// <param name="value">The value of cache item to set.</param>
        protected override void SetCore(string key, object value, CacheOptions options)
        {
            if (options != null)
            {
                var memoryCacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = options.AbsoluteExpiration,
                    AbsoluteExpirationRelativeToNow = options.AbsoluteExpirationRelativeToNow,
                    Priority = (Microsoft.Extensions.Caching.Memory.CacheItemPriority)((int)options.Priority),
                    SlidingExpiration = options.SlidingExpiration
                };
                using (ICacheEntry entry = cache.CreateEntry(key))
                {
                    entry.SetOptions(memoryCacheOptions);
                    entry.Value = value;
                }
            }
            else
            {
                using (ICacheEntry entry = cache.CreateEntry(key))
                {
                    entry.SetOptions(memoryCacheEntryOptions);
                    entry.Value = value;
                }
            }
        }

        /// <summary>
        /// Try to get the value of cache item associated with specified key.
        /// </summary>
        /// <param name="key">The key of cache item to get.</param>
        /// <param name="type">The type of cache item's value to get.</param>
        /// <param name="value">The value of cache item to get.</param>
        /// <returns>A <see cref="bool"/> value indicating whether specified key exists.</returns>
        protected override bool TryGetCore(string key, Type type, out object value)
        {
            return cache.TryGetValue(key, out value);
        }
    }
}
