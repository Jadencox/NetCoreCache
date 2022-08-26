namespace Cache
{
    /// <summary>
    /// Represents the options to determine the expiration policy and priority.
    /// </summary>
    public class CacheOptions
    {
        /// <summary>
        /// Gets or sets an absolute expiration date for the cache entry.
        /// </summary>
        public DateTimeOffset? AbsoluteExpiration { get; set; }

        /// <summary>
        ///  Gets or sets an absolute expiration time, relative to now.
        /// </summary>
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }

        /// <summary>
        /// Gets or sets the priority for keeping the cache entry in the cache during a memory pressure triggered cleanup. The default is Normal.
        /// </summary>
        public CacheItemPriority Priority { get; set; }

        /// <summary>
        /// Gets or sets how long a cache entry can be inactive (e.g. not accessed) before it will be removed. This will not extend the entry lifetime beyond the absolute expiration (if set).
        /// </summary>
        public TimeSpan? SlidingExpiration { get; set; }

        /// <summary>
        /// Initialize a cache options.
        /// </summary>
        public CacheOptions()
        {
            this.Priority = CacheItemPriority.Normal;
        }
    }
}
