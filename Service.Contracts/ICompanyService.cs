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
        Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges);
        Task<CompanyDto> GetCompanyAsync(int id, bool trackChange);

        Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company);

        Task<IEnumerable<CompanyDto>> GetByIdsAsync(IEnumerable<int> ids, bool trackChanges);
        Task<(IEnumerable<CompanyDto> companies, string ids)> CreateCompanyCollectionAsync(IEnumerable<CompanyForCreationDto> companyCollection);

        Task DeleteCompanyAsync(int companyId, bool trackChanges);

        Task UpdateCompanyAsync(int companyId, CompanyForUpdateDto request, bool trackChanges);

    }
}
