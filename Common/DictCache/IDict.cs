using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DictCache
{
    public interface IDict<T>
    {
        /// <summary>
        /// Gets all data by key
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// emove cache by the Key
        /// </summary>
        void Remove();

        /// <summary>
        /// Clear all catch from the cache name
        /// </summary>
        void Clear();
    }
}
