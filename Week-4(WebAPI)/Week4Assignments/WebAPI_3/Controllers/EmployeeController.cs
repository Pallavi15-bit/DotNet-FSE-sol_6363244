using Microsoft.AspNetCore.Mvc;
using WebAPI_3.Models;
using WebAPI_3.Filters;

namespace WebAPI_3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> employees = new();

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            // Simulate error (optional for testing)
            // throw new Exception("This is a test exception");
            return Ok(employees);
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employees.Add(employee);
            return Created("", employee);
        }
    }
}
