using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DTO;

namespace Service
{
    public class EmployeeService:IEmployeeService
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
            var employees = _repositoryManager.Employee.GetEmployees(companyId, false);
         
            var mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return mappedEmployees;
        }
    }
}
