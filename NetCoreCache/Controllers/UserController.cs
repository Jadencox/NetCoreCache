using NetCoreCache.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public WorkStationDbContext _workStationDbContext;

        public UserController(WorkStationDbContext workStationDbContext)
        {
            _workStationDbContext = workStationDbContext;
        }

        [Route("GetUsers")]
        [HttpGet]
        public List<SysUser> GetUsers() 
        {
            var query = from a in _workStationDbContext.SysUser
                        select a;
            return query.ToList();
        }
    }
}
