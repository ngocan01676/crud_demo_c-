using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.EmployeeData
{
    public class SqlEmployeeData : IEmployeeData
    {
        private EmployeeContext _employeeContext;
        public SqlEmployeeData(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }
            

        public void deleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee editEmployee(Employee employee)
        {
            var existingEmploy = _employeeContext.Employees.Find(employee.Id);
            if (existingEmploy != null)
            {
                existingEmploy.Name = employee.Name;
                _employeeContext.Employees.Update(existingEmploy);
                _employeeContext.SaveChanges();
            }

            return employee;
        }

        public Employee GetEmployee(Guid id)
        {
            return _employeeContext.Employees.Find(id);
        }

        public List<Employee> GetEmployees()
        {
           return  _employeeContext.Employees.ToList();
        }
    }
}
