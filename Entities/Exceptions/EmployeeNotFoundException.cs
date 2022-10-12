using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(int employeeId) : base($"Employee with id={employeeId} doesn't exists")
        {
        }
    }
}
