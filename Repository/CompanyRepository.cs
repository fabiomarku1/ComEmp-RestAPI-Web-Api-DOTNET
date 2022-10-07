using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(e => e.Name).ToList();

        public Company GetCompany(int id) => FindById(id);
        public void CreateCompany(Company company) => Create(company);
        public IEnumerable<Company> GetByIds(IEnumerable<int> ids) => FindByCondition(x => ids.Contains(x.Id), trackChanges: false).ToList();

    }
}