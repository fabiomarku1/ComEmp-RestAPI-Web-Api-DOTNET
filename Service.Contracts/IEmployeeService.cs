using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetEmployeesAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges);

        Task<EmployeeDto> GetEmployeeAsync(int employeeId, int companyId, bool trackChanges);

        Task<EmployeeDto> CreateEmployeeForCompanyServiceAsync(int companyId, EmployeeForCreationDto request, bool trackChanges);

        Task DeleteEmployeeForCompanyAsync(int companyId, int employeeId, bool trackChanges);

        Task UpdateEmployeeForCompanyAsync(int companyId, int employeeId, EmployeeForUpdateDto request, bool companyTackChanges, bool employeeTackChanges);
    }
}
