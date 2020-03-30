using Pumox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox.Interfaces
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {        
        Task<Company> GetCompanyByIdAsync(long id);
        void CreateCompany(Company company);
        IEnumerable<Company> SearchCompany(SearchQuery searchQuery);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
