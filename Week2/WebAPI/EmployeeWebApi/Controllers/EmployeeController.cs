using Microsoft.AspNetCore.Mvc;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> employees = new()
        {
            new Employee
            {
                Id = 1,
                Name = "Satyam",
                Salary = 50000,
                Department = new Department
                {
                    Id = 1,
                    Name = "IT"
                },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = ".NET" }
                }
            },
            new Employee
            {
                Id = 2,
                Name = "Rahul",
                Salary = 60000,
                Department = new Department
                {
                    Id = 2,
                    Name = "HR"
                },
                Skills = new List<Skill>
                {
                    new Skill { Id = 3, Name = "Communication" }
                }
            }
        };

        // GET ALL
        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employees);
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        // POST
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employee.Id = employees.Max(e => e.Id) + 1;
            employees.Add(employee);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = employee.Id },
                employee);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            employee.Name = updatedEmployee.Name;
            employee.Salary = updatedEmployee.Salary;
            employee.Department = updatedEmployee.Department;
            employee.Skills = updatedEmployee.Skills;

            return Ok(employee);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
                return NotFound();

            employees.Remove(employee);

            return Ok("Employee deleted successfully.");
        }
    }
}