using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EmployeeData;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {   
        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
           _employeeData = employeeData;
        }

        [HttpGet]
        [Route ("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"Employee with Id:{id} Was not found ");
        }

        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" +HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteEmployee(Guid id)
        {

            var employee = _employeeData.GetEmployee(id);
            if (employee != null)
            {
                _employeeData.deleteEmployee(employee);
                return Ok("Done");
            }
            return NotFound($"Employee with Id:{id} Was not found ");
        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult UpdateEmployee(Guid id,Employee employee)
        {

            var currentEmployee = _employeeData.GetEmployee(id);
            if (currentEmployee != null) { 

                employee.Id = currentEmployee.Id;
                _employeeData.editEmployee(employee);
                return Ok("Done");
            }
            return NotFound($"Employee with Id:{id} Was not found ");
        }



    }
}
