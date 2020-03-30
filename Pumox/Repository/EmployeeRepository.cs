using Pumox.Interfaces;
using Pumox.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pumox.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(PumoxContext pumoxContext)
            : base(pumoxContext)
        {
        }

        public IEnumerable<Employee> FindEmployeesByCompany(long companyId)
        {
            return FindByCondition(p => p.CompanyId == companyId).ToList();
        }
    }
}
