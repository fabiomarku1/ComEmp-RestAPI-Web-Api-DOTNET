using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges) =>
           await FindByCondition(e => e.CompanyId.Equals(companyId) && (e.Age >= employeeParameters.MinAge && e.Age <= employeeParameters.MaxAge), trackChanges)
               .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
               .Search(employeeParameters.SearchTerm)
               .Sort(employeeParameters.SearchTerm)
               //   .OrderBy(e => e.Name)
               .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
                .Take(employeeParameters.PageSize)
                .ToListAsync();

        public async Task<Employee> GetEmployeeAsync(int companyId, int employeeId, bool trackChanges) =>
           await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id == employeeId, trackChanges).SingleOrDefaultAsync();


        public void CreateEmployeeForCompany(int companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);

    }
}
