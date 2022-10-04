using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    internal class EmployeeRepository:RepositoryBase<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
