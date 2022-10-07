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
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetEmployeesService(int companyId, bool trackChanges)
        {

            var company = _repositoryManager.Company.GetCompany(companyId);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var employees = _repositoryManager.Employee.GetEmployees(companyId, false);

            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployees;
        }

        public EmployeeDto GetEmployee(int employeeId, int companyId)
        {
            var company = _repositoryManager.Company.GetCompany(companyId);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var employee = _repositoryManager.Employee.GetEmployee(employeeId, companyId);

            var mapped = _mapper.Map<EmployeeDto>(employee);
            return mapped;
        }

        public EmployeeDto CreateEmployeeForCompanyService(int companyId, EmployeeForCreationDto request, bool trackChanges)
        {
           var company=_repositoryManager.Company.GetCompany(companyId);
           if(company == null) throw new CompanyNotFoundException(companyId);

           var mappedEmployee=_mapper.Map<Employee>(request);

            _repositoryManager.Employee.CreateEmployeeForCompany(companyId, mappedEmployee);
            _repositoryManager.Save();

            var returnEmployee = _mapper.Map<EmployeeDto>(mappedEmployee);
            return returnEmployee;
        }
    }
}
