using DepartmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetDepartmentData()
        {
            using (var dbContext=new DepartmentDBContext())
            {
                return Ok(dbContext.Departments.ToList());
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            using (var dbContext=new DepartmentDBContext())
            {
                var department = dbContext.Departments.Where(x=> x.Deptid==id).FirstOrDefault();
                return Ok(department);
                
            }
        }

        [HttpPost]
        public void InsertDeparment([FromBody]DepartmentData data)
        {
            using(var dbContext=new DepartmentDBContext())
            {
                dbContext.Departments.Add(new Department()
                {
                    Deptid = data.Id,
                    Deptname = data.Dname

                });

                dbContext.SaveChanges();  
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(DepartmentData data)
        {
            using (var dbContext = new DepartmentDBContext())
            {
               Department dept = dbContext.Departments.Where(x => x.Deptid == data.Id).FirstOrDefault();

                if (dept!= null)
                {
                    dept.Deptid = data.Id;
                    dept.Deptname = data.Dname;
                }
                else
                {
                    return BadRequest(StatusCodes.Status400BadRequest);

                }

                dbContext.Departments.Update(dept);
                dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            using(var dbContext=new DepartmentDBContext())
            {
               var data= dbContext.Departments.Where(x => x.Deptid == id).FirstOrDefault();
                dbContext.Departments.Remove(data);
                dbContext.SaveChanges();
            }

            return Ok();
        }

    }
}
