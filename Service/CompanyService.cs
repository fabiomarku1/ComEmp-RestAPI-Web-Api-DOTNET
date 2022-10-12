using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
        {
            var companies = await _repositoryManager.Company.GetAllCompaniesAsync(trackChanges);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;
        }


        public async Task<CompanyDto> GetCompanyAsync(int id, bool trackChange)
        {
            var comapny = await _repositoryManager.Company.GetCompanyAsync(id, trackChange);

            if (comapny == null) throw new CompanyNotFoundException(id);

            var mapped = _mapper.Map<CompanyDto>(comapny);
            return mapped;
        }

        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
        {
            var mappedCompany = _mapper.Map<Company>(company);
            _repositoryManager.Company.CreateCompany(mappedCompany);

            await _repositoryManager.SaveAsync();

            var returnCompany = _mapper.Map<CompanyDto>(mappedCompany);
            return returnCompany;

        }

        public async Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges)
        {
            if (ids is null) throw new IdParametersBadRequestException();
            var companies = await _repositoryManager.Company.GetByIdsAsync(ids, trackChanges);

            if (ids.Count() != companies.Count()) throw new IdParametersBadRequestException();

            var mapped = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return mapped;
        }

        public async Task<(IEnumerable<CompanyDto> companies, string ids)>
            CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();
            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);

            foreach (var company in companyEntities)
            {
                _repositoryManager.Company.CreateCompany(company);
            }
            await _repositoryManager.SaveAsync();

            var companyCollectionToReturn =
            _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

            return (companies: companyCollectionToReturn, ids: ids);
        }

        public async Task DeleteCompanyAsync(int companyId, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null) throw new CompanyNotFoundException(companyId);

            _repositoryManager.Company.DeleteCompany(company);
            await _repositoryManager.SaveAsync();

        }

        public async Task UpdateCompanyAsync(int companyId, CompanyForUpdateDto request, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null) throw new CompanyNotFoundException(companyId);

            _mapper.Map(request, company);
            await _repositoryManager.SaveAsync();
        }
    }
}
