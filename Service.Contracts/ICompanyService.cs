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
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        public IEnumerable<CompanyDto> Test(bool trackChanges);
        CompanyDto GetCompanyIdFromService(int id);

        CompanyDto CreateCompanyService(CompanyForCreationDto company);

        IEnumerable<CompanyDto> GetByIds(IEnumerable<int> ids);
        (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection);

    }
}
