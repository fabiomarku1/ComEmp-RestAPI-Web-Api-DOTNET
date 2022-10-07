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


        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;
        }

        public IEnumerable<CompanyDto> Test(bool trackChanges)
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);

            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;
        }

        public CompanyDto GetCompanyIdFromService(int id)
        {
            var comapny = _repositoryManager.Company.GetCompany(id);
            var mapped = _mapper.Map<CompanyDto>(comapny);
            return mapped;
        }

        public CompanyDto CreateCompanyService(CompanyForCreationDto company)
        {
            var mappedCompany = _mapper.Map<Company>(company);

            _repositoryManager.Company.CreateCompany(mappedCompany);
            _repositoryManager.Save();

            var returnCompany = _mapper.Map<CompanyDto>(mappedCompany);
            return returnCompany;

        }

        public IEnumerable<CompanyDto> GetByIds(IEnumerable<int> ids)
        {
            if (ids is null) throw new IdParametersBadRequestException();
            var companies = _repositoryManager.Company.GetByIds(ids);

            if (ids.Count() != ids.Count()) throw new IdParametersBadRequestException();

            var mapped = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return mapped;
        }

        public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();
            var companyEntities = _mapper.Map<IEnumerable<Company>>(companyCollection);
            foreach (var company in companyEntities)
            {
                _repositoryManager.Company.CreateCompany(company);
            }
            _repositoryManager.Save();
            var companyCollectionToReturn =
            _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

            return (companies: companyCollectionToReturn, ids: ids);
        }

    }
}
