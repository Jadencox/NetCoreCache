namespace Cache
{
    /// <summary>
    /// Represents a factory to create a cache.
    /// </summary>
    public interface ICacheFactory
    {
        /// <summary>
        /// Get cache based on the specified name and options.
        /// </summary>
        /// <param name="name">The name of cache to get.</param>
        /// <param name="options">The options appying to the created cache.</param>
        /// <returns>The cache to get.</returns>
        /// <remarks>All caches created by a cache factory have unique names. If the specified name exists, an associated cache will be returned, otherwize a new cache is created.</remarks>
        ICache GetCache(string name, CacheOptions options);
    }
}
