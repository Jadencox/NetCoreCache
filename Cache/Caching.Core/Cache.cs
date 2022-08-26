namespace Cache
{
    /// <summary>
    /// Base of all concrete cache classes.
    /// </summary>
    public abstract class Cache : ICache
    {
        #region Constants
        /// <summary>
        /// The keys of all cache items start with this prefix.
        /// </summary>
        public const string Prefix = "Core.Caching";
        #endregion

        #region Properties
        /// <summary>
        /// The name to uniquely identify the cache.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The options which determine the expiration policy and priority of cache items.
        /// </summary>
        public CacheOptions Options { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a new cache.
        /// </summary>
        /// <param name="name">The name of the cache to create.</param>
        /// <param name="options">The options applied to created cache.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="name"/> is empty or white space.</exception>
        public Cache(string name, CacheOptions options)
        {
            //Guard.ArgumentNotNullOrWhiteSpace(name, "name");
            //Guard.ArgumentNotNull(options, "options");

            this.Name = name;
            this.Options = options;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Clear all cache items added to current cache.
        /// </summary>
        public void Clear()
        {
            foreach (var key in this.GetKeys())
            {
                this.RemoveCore(this.GenerateRealKey(key));
            }
            this.RemoveCore(this.GenerateKeyOfKeys());
        }

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
        public void Set(string key, object value)
        {
            //Guard.ArgumentNotNullOrWhiteSpace(key, "key");
            //Guard.ArgumentNotNull(value, "value");

            List<string> keys = this.GetKeys();
            if (!keys.Contains(key))
            {
                keys.Add(key);
            }
            key = this.GenerateRealKey(key);
            this.SetCore(key, value);
            this.SetKeysAsList(keys);
        }

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
        public void Set(string key, object value, CacheOptions options)
        {
            //Guard.ArgumentNotNullOrWhiteSpace(key, "key");
            //Guard.ArgumentNotNull(value, "value");

            List<string> keys = this.GetKeys();
            if (!keys.Contains(key))
            {
                keys.Add(key);
            }
            key = this.GenerateRealKey(key);
            this.SetCore(key, value, options);
            this.SetKeysAsList(keys);
        }


        /// <summary>
        /// Gets the value of cache item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of cache item whose value to get.</param>
        /// <param name="type">The type of the cache item's value to get.</param>
        /// <param name="value">The value of cache item to get. It will be null of specified key does not exist.</param>
        /// <returns>A <see cref="bool"/> value indicating whether the specified key exists.</returns>
        /// <exception cref="ArgumentNullException">Either<paramref name="key"/> or <paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty or white space.</exception>
        public bool TryGet(string key, Type type, out object value)
        {
            //Guard.ArgumentNotNullOrWhiteSpace(key, "key");
            //Guard.ArgumentNotNull(type, "type");
            return this.TryGetCore(this.GenerateRealKey(key), type, out value);
        }

        /// <summary>
        /// Remove the cache item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of cache item to remove.</param>
        public void Remove(string key)
        {
            //Guard.ArgumentNotNullOrWhiteSpace(key, "key");

            this.RemoveCore(this.GenerateRealKey(key));
            List<string> keys = this.GetKeys();
            if (keys.Contains(key))
            {
                keys.Remove(key);
            }
            this.SetKeysAsList(keys);
        }

        /// <summary>
        /// Get all keys of cache items.
        /// </summary>
        /// <returns>The keys of cache items.</returns>
        /// <remarks>This method returns an empty string collection if there is no cache items.</remarks>
        public IEnumerable<string> GetAllKeys()
        {
            return this.GetKeys();
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Remove the cache item associated with the specified key.
        /// </summary>
        /// <param name="key">The key of cache item to remove.</param>
        protected abstract void RemoveCore(string key);

        /// <summary>
        /// Set (add or update) a cache item using specified key and value.
        /// </summary>
        /// <param name="key">The key of cache item to set.</param>
        /// <param name="value">The value of cache item to set.</param>
        protected abstract void SetCore(string key, object value);

        /// <summary>
        /// Set (add or update) a cache item using specified key and value.
        /// </summary>
        /// <param name="key">The key of cache item to set.</param>
        /// <param name="value">The value of cache item to set.</param>
        protected abstract void SetCore(string key, object value, CacheOptions options);

        /// <summary>
        /// Try to get the value of cache item associated with specified key.
        /// </summary>
        /// <param name="key">The key of cache item to get.</param>
        /// <param name="type">The type of cache item's value to get.</param>
        /// <param name="value">The value of cache item to get.</param>
        /// <returns>A <see cref="bool"/> value indicating whether specified key exists.</returns>
        protected abstract bool TryGetCore(string key, Type type, out object value);
        #endregion

        #region Internal Methods
        internal string GenerateRealKey(string key)
        {
            return $"{Prefix}.{this.Name}.{key}";
        }
        internal string GenerateKeyOfKeys()
        {
            return $"{Prefix}.{this.Name}.Keys";
        }

        internal List<string> GetKeys()
        {
            string keyOfKeys = this.GenerateKeyOfKeys();
            return this.TryGetCore(keyOfKeys, typeof(List<string>), out var keys1)
                ? (List<string>)keys1
                : new List<string>();
        }
        internal void SetKeysAsList(List<string> keys)
        {
            this.SetCore(this.GenerateKeyOfKeys(), keys);
        }

        internal void ClearKeys()
        {
            string keyOfKeys = this.GenerateKeyOfKeys();
            this.RemoveCore(keyOfKeys);
        }
        #endregion
    }
}
