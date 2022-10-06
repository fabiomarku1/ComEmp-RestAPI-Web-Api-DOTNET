using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CompanyNotFoundException:NotFoundException
    {
        public CompanyNotFoundException(int  id)
            : base($"The company with id={id} doesn't exists")
        {
        }
    }
}
