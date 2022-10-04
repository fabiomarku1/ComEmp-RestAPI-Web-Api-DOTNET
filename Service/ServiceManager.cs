using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;

        public ServiceManager(IRepositoryManager repositoryManager,ILoggerManager loggerManager)
        {
            _companyService = new Lazy<ICompanyService>(() => new
                CompanyService(repositoryManager, loggerManager));

            _companyService=new Lazy<IEmployeeService>(() => new

        }
    }
}
