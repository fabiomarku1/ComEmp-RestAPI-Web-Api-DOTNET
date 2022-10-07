using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

namespace Company2.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]

    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetEmployees(int companyId)
        {
            var employees = _service.EmployeeService.GetEmployeesService(companyId, false);
            return Ok(employees);
        }

        [HttpGet("{employeeId:int}", Name = "GetSpecificEmployee")]
        public IActionResult GetSpecificEmployee(int companyId, int employeeId)
        {
            var employee = _service.EmployeeService.GetEmployee(employeeId, companyId);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(int companyId, [FromBody] EmployeeForCreationDto request)
        {
            if (request == null) return BadRequest("Field is null");
            var employee = _service.EmployeeService.CreateEmployeeForCompanyService(companyId, request, false);

            return CreatedAtRoute("GetSpecificEmployee", new { companyId, employeeId = employee.Id }, employee);


        }


    }
}
