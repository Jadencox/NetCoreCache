using Common.DictTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Common.DictCache
{
    public class DictFactory : IDictFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DictFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IDict<T> GetDict<T>()
        {
            return _serviceProvider.GetService<IDict<T>>();
        }
        public void Initialize()
        {
            DeptDict.ToList();
        }
        public IEnumerable<DeptDict> DeptDict => _serviceProvider.GetService<IDict<DeptDict>>().GetAll();

    }
}
