using Common.DictTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DictCache
{
    public interface IDictFactory
    {

        IDict<T> GetDict<T>();

        void Initialize();

        IEnumerable<DeptDict> DeptDict { get; }

    }
}
