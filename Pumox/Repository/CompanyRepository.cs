using Microsoft.EntityFrameworkCore;
using Pumox.Interfaces;
using Pumox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(PumoxContext pumoxContext)
            : base(pumoxContext)
        {
        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public void UpdateCompany(Company company)
        {
            Update(company);
        }

        public void DeleteCompany(Company company)
        {
            Delete(company);
        }

        public async Task<Company> GetCompanyByIdAsync(long id)
        {
            return await FindByCondition(p => p.Id.Equals(id))
                    .FirstOrDefaultAsync();
        }

        public IEnumerable<Company> SearchCompany(SearchQuery searchQuery)
        {
            IEnumerable<Company> result = FindByCondition(
                p => p.Name.Contains(searchQuery.Keyword) ||
                p.Employees.Any(p => p.FirstName.Contains(searchQuery.Keyword)) ||
                p.Employees.Any(p => p.LastName.Contains(searchQuery.Keyword))
                )
                .Include(p => p.Employees);

            if (searchQuery.EmployeeDateOfBirthFrom != default(DateTime))
            {
                result = result.Where(p => p.Employees.Any(p => p.DateOfBirth >= searchQuery.EmployeeDateOfBirthFrom));
            }

            if (searchQuery.EmployeeDateOfBirthTo != default(DateTime))
            {
                result = result.Where(p => p.Employees.Any(p => p.DateOfBirth <= searchQuery.EmployeeDateOfBirthTo));
            }

            if (searchQuery.EmployeeJobTitles != null && searchQuery.EmployeeJobTitles.Count > 0)
            {
                HashSet<JobTitle> Jobs = new HashSet<JobTitle>();

                foreach (string jobTitleStr in searchQuery.EmployeeJobTitles)
                {
                    Jobs.Add((JobTitle)Enum.Parse(typeof(JobTitle), jobTitleStr));
                }

                result = result.Where(p => p.Employees.Any(p => Jobs.Contains(p.JobTitle)));
            }

            return result.ToList();
        }
    }
}
