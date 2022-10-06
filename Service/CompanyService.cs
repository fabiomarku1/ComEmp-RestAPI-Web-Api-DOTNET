using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DTO;

namespace Service
{
    public sealed class CompanyService:ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager,IMapper mapper)
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
    }
}
