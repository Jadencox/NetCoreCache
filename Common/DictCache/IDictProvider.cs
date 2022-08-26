using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DictCache
{
    public interface IDictProvider<T>
    {
        /// <summary>
        /// Gets all data by key
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Remove cache by the Key
        /// </summary>
        void Remove();

        /// <summary>
        ///  Gets all category names.
        /// </summary>
        void Clear();
    }
}
