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
using Shared.RequestFeatures;

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

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {

            if (!employeeParameters.ValidAgeRange) throw new MaxAgeRangeBadRequestException();
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var employees = await _repositoryManager.Employee.GetEmployeesAsync(companyId, employeeParameters, trackChanges);

            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployees;
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int employeeId, int companyId, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var employee = await _repositoryManager.Employee.GetEmployeeAsync(companyId, employeeId, trackChanges);
            if (employee == null) throw new EmployeeNotFoundException(employeeId);

            var mapped = _mapper.Map<EmployeeDto>(employee);
            return mapped;
        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyServiceAsync(int companyId, EmployeeForCreationDto request, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var mappedEmployee = _mapper.Map<Employee>(request);

            _repositoryManager.Employee.CreateEmployeeForCompany(companyId, mappedEmployee);
            await _repositoryManager.SaveAsync();

            var returnEmployee = _mapper.Map<EmployeeDto>(mappedEmployee);
            return returnEmployee;
        }

        public async Task DeleteEmployeeForCompanyAsync(int companyId, int employeeId, bool trackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var employee = await _repositoryManager.Employee.GetEmployeeAsync(companyId, employeeId, trackChanges);
            if (employee == null) throw new EmployeeNotFoundException(employeeId);

            _repositoryManager.Employee.DeleteEmployee(employee);
            await _repositoryManager.SaveAsync();

        }

        public async Task UpdateEmployeeForCompanyAsync(int companyId, int employeeId, EmployeeForUpdateDto request, bool companyTackChanges,
            bool employeeTackChanges)
        {
            var company = await _repositoryManager.Company.GetCompanyAsync(companyId, companyTackChanges);
            if (company == null) throw new CompanyNotFoundException(companyId);

            var employee = await _repositoryManager.Employee.GetEmployeeAsync(companyId, employeeId, employeeTackChanges); //here
            if (employee == null) throw new EmployeeNotFoundException(employeeId);

            _mapper.Map(request, employee);
            await _repositoryManager.SaveAsync();
            //track changes may give error;

        }
    }
}
