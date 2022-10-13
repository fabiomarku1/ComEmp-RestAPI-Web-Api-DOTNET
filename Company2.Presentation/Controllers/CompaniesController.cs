using Company2.Presentation.ModelBinders;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET , PUT , DELETE , OPTIONS , POST");
            return Ok();
        }

        [HttpGet(Name = "GetCompanies")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _services.CompanyService.GetAllCompaniesAsync(false);
            return Ok(companies);
        }

        [HttpGet("collections/ids", Name = "CompanyCollection")]
        public async Task<IActionResult> GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            var companies = await _services.CompanyService.GetByIdsAsync(ids, false);
            return Ok(companies);

        }


        [HttpGet("{id:int}", Name = "CompanyById")]
        //  [ResponseCache(Duration = 60)]
        public async Task<IActionResult> GetCompany(int id)
        {
            var company = await _services.CompanyService.GetCompanyAsync(id, false);

            if (company == null) throw new CompanyNotFoundException(id);

            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto request)
        {
            if (request is null) return BadRequest("Company is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var createCompany = await _services.CompanyService.CreateCompanyAsync(request);



            return CreatedAtRoute("CompanyById", new
            {
                id = createCompany.Id
            }, createCompany);

        }

        [HttpPost("collections")]
        public async Task<IActionResult> CreateCompanyCollections([FromBody] IEnumerable<CompanyForCreationDto> companyCollections)
        {
            var result = await _services.CompanyService.CreateCompanyCollectionAsync(companyCollections);

            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);

        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCompany(int id, CompanyForUpdateDto request)
        {
            if (request is null)
                return BadRequest("CompanyForUpdateDto object is null");

            await _services.CompanyService.UpdateCompanyAsync(id, request, true);
            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _services.CompanyService.DeleteCompanyAsync(id, false);
            return NoContent();
        }


    }
}
