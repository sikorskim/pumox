using Pumox.Interfaces;
using Pumox.Models;
using System.Threading.Tasks;

namespace Pumox.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private PumoxContext _pumoxContext;
        private ICompanyRepository _company;
        private IEmployeeRepository _employee;

        public ICompanyRepository Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_pumoxContext);
                }

                return _company;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_pumoxContext);
                }

                return _employee;
            }
        }

        public RepositoryWrapper(PumoxContext pumoxContext)
        {
            _pumoxContext = pumoxContext;
        }

        public async Task SaveAsync()
        {
            await _pumoxContext.SaveChangesAsync();
        }
    }
}
