using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

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

        [HttpGet("collections/ids", Name = "CompanyCollection")]
        public IActionResult GetCompanyCollection(IEnumerable<int> ids)
        {
            var companies = _services.CompanyService.GetByIds(ids);
            return Ok(companies);

        }


        [HttpGet("{id:int}", Name = "CompanyById")]
        public IActionResult GetCompanyId(int id)
        {
            var company = _services.CompanyService.GetCompanyIdFromService(id);

            if (company == null) throw new CompanyNotFoundException(id);

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto request)
        {
            if (request == null) return BadRequest("Company is null");
            var createCompany = _services.CompanyService.CreateCompanyService(request);

            return CreatedAtRoute("CompanyById", new { id = createCompany.Id }, createCompany);

        }

        [HttpPost("collections")]
        public IActionResult CreateCompanyCollections([FromBody] IEnumerable<CompanyForCreationDto> companyCollections)
        {
            var result = _services.CompanyService.CreateCompanyCollection(companyCollections);

            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);

        }


    }
}
