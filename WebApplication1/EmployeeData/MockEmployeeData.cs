using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EmployeeData
{
    public class MockEmployeeData : IEmployeeData
    {

        private List<Employee> employees = new List<Employee>(){

            new Employee()
            {

                Id = Guid.NewGuid(),
                Name = "EMployee One"
            },
            new Employee()
            {

                Id = Guid.NewGuid(),
                Name = "EMployee One"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void deleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee editEmployee(Employee employee)
        {
            var existEmployee = this.GetEmployee(employee.Id);
            existEmployee.Name = employee.Name;
            return existEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.SingleOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
