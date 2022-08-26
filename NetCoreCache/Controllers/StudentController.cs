using NetCoreCache.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public WorkStationDbContext _workStationDbContext;

        public StudentController(WorkStationDbContext workStationDbContext)
        {
            _workStationDbContext = workStationDbContext;
        }

        [Route("InsertStu")]
        [HttpPost]
        public bool InsertStu(Student student)
        {
            student.CreateTime = DateTime.Now;
            _workStationDbContext.Student.Add(student);
            return _workStationDbContext.SaveChanges() > 0;
        }

        [Route("GetStu")]
        [HttpGet]
        public List<Student> GetStu()
        {
            var query = from a in _workStationDbContext.Student
                        select a;
            return query.ToList();
        }
    }
}
