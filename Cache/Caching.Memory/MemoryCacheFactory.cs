using Microsoft.Extensions.Caching.Memory;

namespace Cache
{
    /// <summary>
    /// A cache factory to provide <see cref="MemoryCache"/>.
    /// </summary>
    public class MemoryCacheFactory : CacheFactory
    {
        private readonly IMemoryCache cache;

        /// <summary>
        /// Initialize a new memory cache factory.
        /// </summary>
        /// <param name="cache">A memory cache used to store cache item.</param>
        /// <exception cref="ArgumentNullException"><paramref name="cache"/> argument is null.</exception>
        public MemoryCacheFactory(IMemoryCache cache)
        {
            //Guard.ArgumentNotNull(cache, "cache");
            this.cache = cache;
        }

        /// <summary>
        /// Create the cache using specified name and cache options.
        /// </summary>
        /// <param name="name">The name of cache to create.</param>
        /// <param name="options">The cache options applied to created cache.</param>
        /// <returns>The created cache.</returns>
        ///<exception cref="ArgumentNullException">Either <paramref name="name"/> or <paramref name="options"/> is null.</exception>
        ///<exception cref="ArgumentException"><paramref name="name"/> is empty or white space.</exception>
        protected override ICache CreateCacheCore(string name, CacheOptions options)
        {
            return new MemoryCache(cache, name, options);
        }
    }
}
