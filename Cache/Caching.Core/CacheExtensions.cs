namespace Cache
{
    /// <summary>
    /// <see cref="ICache"/> specific extension methods are defined in this class.
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// Try to get the value of cache item associated with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of cache item's value to get.</typeparam>
        /// <param name="cache">The cache which stores the cache item to get.</param>
        /// <param name="key">The key of cache item to get.</param>
        /// <param name="value">The value of cache item to get.</param>
        /// <returns>A <see cref="bool"/> value indicating whether cache item associated with the specified key exists.</returns>
        /// <exception cref="ArgumentNullException">Either<paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty or white space.</exception>
        /// <exception cref="InvalidCastException">The type T is not assignable from the value of cache item to get.</exception>
        public static bool TryGet<T>(this ICache cache, string key, out T value)
        {
            //Guard.ArgumentNotNull(cache, "cache");
            //Guard.ArgumentNotNullOrWhiteSpace(key, "key");

            object value1;
            if (cache.TryGet(key, typeof(T), out value1))
            {
                value = (T)value1;
                return true;
            }
            value = default(T);
            return false;
        }

        /// <summary>
        /// Get the value of cache item associated with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of cache item's value to get.</typeparam>
        /// <param name="cache">The cache which stores the cache item to get.</param>
        /// <param name="key">The key of cache item to get.</param>
        /// <param name="defaultValue">The return value if cache item associated with the specified key does not exist.</param>
        /// <returns>If cache item associated with the specified key exists, its value will be returned, otherwise the <paramref name="defaultValue"/> returns.</returns>
        /// <exception cref="ArgumentNullException">Either<paramref name="key"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="key"/> is empty or white space.</exception>
        /// <exception cref="InvalidCastException">The type T is not assignable from the value of cache item to get.</exception>
        public static T Get<T>(this ICache cache, string key, T defaultValue = default(T))
        {
            T value;
            return TryGet(cache, key, out value) ? value : defaultValue;
        }

        #region With only one params for Function.

        /// <summary>
        /// 带一个参数的 自定义 catch 方法
        /// </summary>
        /// <typeparam name="TM"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="f"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static T Get<TM, T>(this ICache cache, string key, Func<TM, T> f, TM m, CacheOptions cacheOptions = null)
        {
            T value;
            var exists = TryGet(cache, key, out value);
            if (exists)
                return value;
            var tempValue = f(m);
            if (null != cacheOptions)
                cache.Set(key, tempValue, cacheOptions);
            else
                cache.Set(key, tempValue);
            return tempValue;

        }

        /// <summary>
        /// 带两个参数的 自定义 catch 方法
        /// </summary>
        /// <typeparam name="TM"></typeparam>
        /// <typeparam name="TN"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache"></param>
        /// <param name="key"></param>
        /// <param name="f"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static T Get<TM, TN, T>(this ICache cache, string key, Func<TM, TN, T> f, TM m, TN n, CacheOptions cacheOptions = null)
        {
            T value;
            var exists = TryGet(cache, key, out value);
            if (exists)
                return value;
            var tempValue = f(m, n);
            if (null != cacheOptions)
                cache.Set(key, tempValue, cacheOptions);
            else
                cache.Set(key, tempValue);
            return tempValue;

        }


        #endregion
    }
}
