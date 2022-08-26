using Cache;
using Common.DictCache;
using Common.DictContext;
using Common.DictTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DictProviders
{
    public class DeptDictProvider : Dict<DeptDict>
    {
        private readonly DictDbContext _dictDbContext;

        public DeptDictProvider(ICacheFactory cacheFactory, DictDbContext dictDbContext) : base(cacheFactory)
        {
            _dictDbContext = dictDbContext;
        }

        protected override IEnumerable<DeptDict> GetAllData()
        {
            return _dictDbContext.DeptDict.ToList();
        }

    }
}

