namespace Cache
{
    public interface ICache
    {
        /// <summary>
        /// The name to uniquely identify the cache.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The options which determine the expiration policy and priority of cache items.
        /// </summary>
        CacheOptions Options { get; }

        /// <summary>
        /// Add a new cache item or update the value of an existing cache item.
        /// </summary>
        /// <remarks>
        /// If specified key exists, a new cache item will be added, otherwize the value of an existing cache item will be overriden.
        /// </remarks>
        /// <param name="key">The key of cache item to be added or updated.</param>
        /// <param name="value">The value of cache item to add or update.</param>
        /// <exception cref="ArgumentNullException">Either<paramref name="key"/> or <paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty or white space.</exception>
        void Set(string key, object value);

        /// <summary>
        /// Add a new cache item or update the value of an existing cache item.
        /// </summary>
        /// <remarks>
        /// If specified key exists, a new cache item will be added, otherwize the value of an existing cache item will be overriden.
        /// </remarks>
        /// <param name="key">The key of cache item to be added or updated.</param>
        /// <param name="value">The value of cache item to add or update.</param>
        /// <exception cref="ArgumentNullException">Either<paramref name="key"/> or <paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty or white space.</exception>
        void Set(string key, object value, CacheOptions options);

        /// <summary>
        /// Gets the value of cache item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of cache item whose value to get.</param>
        /// <param name="type">The type of the cache item's value to get.</param>
        /// <param name="value">The value of cache item to get. It will be null of specified key does not exist.</param>
        /// <returns>A <see cref="bool"/> value indicating whether the specified key exists.</returns>
        /// <exception cref="ArgumentNullException">Either<paramref name="key"/> or <paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty or white space.</exception>
        bool TryGet(string key, Type type, out object value);

        /// <summary>
        /// Remove the cache item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of cache item to remove.</param>
        void Remove(string key);

        /// <summary>
        /// Clear all cache items added in current cache.
        /// </summary>
        void Clear();

        /// <summary>
        /// Get all keys of cache items.
        /// </summary>
        /// <returns>The keys of cache items.</returns>
        /// <remarks>This method returns an empty string collection if there is no cache items.</remarks>
        IEnumerable<string> GetAllKeys();
    }
}
