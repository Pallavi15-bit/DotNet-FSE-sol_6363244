using Microsoft.AspNetCore.Mvc;
using WebAPI_4.Models;

namespace WebAPI_4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> employees = new()
        {
            new Employee { Id = 1, Name = "John", Department = "HR" },
            new Employee { Id = 2, Name = "Jane", Department = "Finance" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get() => Ok(employees);

        [HttpPut("{id}")]
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            emp.Name = updatedEmp.Name;
            emp.Department = updatedEmp.Department;
            return Ok(emp);
        }
    }
}
