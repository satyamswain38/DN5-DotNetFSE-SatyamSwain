using System.Collections.Generic;

namespace EmployeeWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Salary { get; set; }

        public Department? Department { get; set; }

        public List<Skill>? Skills { get; set; }
    }
}