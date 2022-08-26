namespace Cache
{
    /// <summary>
    /// Represents the relative priority of cache item.
    /// </summary>
    public enum CacheItemPriority
    {
        /// <summary>
        /// Cache items with this priority level are the most likely to be deleted from the cache as the server frees system memory.
        /// </summary>
        Low,

        /// <summary>
        /// Cache items with this priority level are likely to be deleted from the cache as the server frees system memory only after those items with Low or BelowNormal priority. This is the default.
        /// </summary>
        Normal,

        /// <summary>
        /// Cache items with this priority level are the least likely to be deleted from the cache as the server frees system memory.
        /// </summary>
        High,

        /// <summary>
        /// The cache items with this priority level will not be automatically deleted from the cache as the server frees system memory. However, items with this priority level are removed along with other items according to the item's absolute or sliding expiration time.
        /// </summary>
        NeverRemove
    }
}
