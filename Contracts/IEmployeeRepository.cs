﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync(int companyId, EmployeeParameters employeeParameters, bool trackChanges);

        Task<Employee> GetEmployeeAsync(int companyId, int employeeId, bool trackChanges);

        void CreateEmployeeForCompany(int companyId, Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
