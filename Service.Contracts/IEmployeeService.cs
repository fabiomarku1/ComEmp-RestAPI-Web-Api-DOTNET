using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployeesService(int companyId, bool trackChanges);

        EmployeeDto GetEmployee(int employeeId, int companyId);

        EmployeeDto CreateEmployeeForCompanyService(int companyId, EmployeeForCreationDto request,bool trackChanges);
    }
}
