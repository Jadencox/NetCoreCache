using NetCoreCache.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Common.DictTables;
using Common.DictCache;

namespace NetCoreCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public WorkStationDbContext _workStationDbContext;
        public IDictFactory _DictFactory;

        public UserController(WorkStationDbContext workStationDbContext, IDictFactory DictFactory)
        {
            _workStationDbContext = workStationDbContext;
            _DictFactory = DictFactory;
        }

        [Route("GetUsers")]
        [HttpGet]
        public List<SysUser> GetUsers() 
        {
            var query = from a in _workStationDbContext.SysUser
                        select a;
            return query.ToList();
        }

        [Route("GetDept")]
        [HttpGet]
        public List<DeptDict> GetDept()
        {
            var query = _DictFactory.DeptDict.ToList();
            return query.ToList();
        }
    }
}
