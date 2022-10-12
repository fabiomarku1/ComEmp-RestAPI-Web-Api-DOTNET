using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;
using Shared.RequestFeatures;

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
        [HttpHead]
        public async Task<IActionResult> GetEmployees(int companyId, [FromQuery] EmployeeParameters employeeParameters)
        {
            var employees = await _service.EmployeeService.GetEmployeesAsync(companyId, employeeParameters, false);
            return Ok(employees);
        }

        [HttpGet("{employeeId:int}", Name = "GetSpecificEmployee")]
        public async Task<IActionResult> GetSpecificEmployee(int companyId, int employeeId)
        {
            var employee = await _service.EmployeeService.GetEmployeeAsync(employeeId, companyId, false);
            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmployee(int companyId, [FromBody] EmployeeForCreationDto request)
        {
            if (request == null) return BadRequest("Field is null");


            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
            var employee = await _service.EmployeeService.CreateEmployeeForCompanyServiceAsync(companyId, request, false);

            return CreatedAtRoute("GetSpecificEmployee", new { companyId, employeeId = employee.Id }, employee);
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int companyId, int id, [FromBody] EmployeeForUpdateDto request)
        {
            if (request == null) return BadRequest("Employe for update is null");

            if (!ModelState.IsValid) return UnprocessableEntity(ModelState);


            await _service.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, id, request, false, true);
            return NoContent();
        }



        [HttpDelete("{employeeId:int}")]
        public async Task<IActionResult> DeleteEmployee(int companyId, int employeeId)
        {
            await _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, employeeId, false);
            return NoContent();

        }



    }
}
