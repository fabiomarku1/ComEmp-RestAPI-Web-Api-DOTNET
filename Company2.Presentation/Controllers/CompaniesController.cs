using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace Company2.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CompaniesController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _services.CompanyService.GetAllCompanies(false);
            return Ok(companies);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetCompanyId(int id)
        {
            var company = _services.CompanyService.GetCompanyIdFromService(id);

            if (company == null) throw new CompanyNotFoundException(id);

            return Ok(company);
        }
    }
}
