using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Company2.Presentation.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController:ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }


        [HttpGet("{companyId}")]
        public IActionResult GetEmployees(int companyId)
        {
            var company = _service.CompanyService.GetCompanyIdFromService(companyId);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var employees = _service.EmployeeService.GetEmployeesService(companyId, false);
            return Ok(employees);
        }


    }
}
