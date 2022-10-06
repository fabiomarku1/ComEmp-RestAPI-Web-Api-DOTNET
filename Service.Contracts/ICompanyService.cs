using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies (bool trackChanges);
        public IEnumerable<CompanyDto> Test(bool trackChanges);
        CompanyDto GetCompanyIdFromService(int id);
    }
}
