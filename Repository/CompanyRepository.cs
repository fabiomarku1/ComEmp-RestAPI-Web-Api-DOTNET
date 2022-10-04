using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    internal class CompanyRepository:RepositoryBase<Company>,ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {

        }
    }
}
