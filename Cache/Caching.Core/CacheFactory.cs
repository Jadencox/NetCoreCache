using System.Collections.Concurrent;

namespace Cache
{
    public abstract class CacheFactory : ICacheFactory
    {
        private readonly ConcurrentDictionary<string, ICache> caches = new ConcurrentDictionary<string, ICache>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Get cache based on the specified name and options.
        /// </summary>
        /// <param name="name">The name of cache to get.</param>
        /// <param name="options">The options appying to the created cache.</param>
        /// <returns>The cache to get.</returns>
        /// <remarks>All caches created by a cache factory have unique names. If the specified name exists, an associated cache will be returned, otherwize a new cache is created.</remarks>
        ///<exception cref="ArgumentNullException">Either <paramref name="name"/> or <paramref name="options"/> is null.</exception>
        ///<exception cref="ArgumentException"><paramref name="name"/> is empty or white space.</exception>
        public ICache GetCache(string name, CacheOptions options)
        {
            //Guard.ArgumentNotNullOrWhiteSpace(name, "name");
            //Guard.ArgumentNotNull(options, "options");
            ICache cache;
            return caches.TryGetValue(name, out cache) ? cache : caches[name] = this.CreateCacheCore(name, options);
        }

        /// <summary>
        /// Create the cache using specified name and cache options.
        /// </summary>
        /// <param name="name">The name of cache to create.</param>
        /// <param name="options">The cache options applied to created cache.</param>
        /// <returns>The created cache.</returns>
        ///<exception cref="ArgumentNullException">Either <paramref name="name"/> or <paramref name="options"/> is null.</exception>
        ///<exception cref="ArgumentException"><paramref name="name"/> is empty or white space.</exception>
        protected abstract ICache CreateCacheCore(string name, CacheOptions options);
    }
}
