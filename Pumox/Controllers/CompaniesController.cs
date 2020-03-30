using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pumox.DataTransferObjects;
using Pumox.Interfaces;
using Pumox.Models;

namespace Pumox.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CompaniesController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //// POST: api/Companies
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.        
        [HttpPost("Create")]
        public async Task<ActionResult<long>> Create([FromBody]CompanyForCreationDto company)
        {
            try
            {
                if (company == null)
                {                    
                    return BadRequest("Company object is null");
                }
                else if (!ModelState.IsValid)
                {                 
                    return BadRequest("Invalid model object");
                }

                var companyEntity = _mapper.Map<Company>(company);

                _repository.Company.CreateCompany(companyEntity);
                await _repository.SaveAsync();

                var createdCompany = _mapper.Map<CompanyDto>(companyEntity);

                return StatusCode(StatusCodes.Status201Created, createdCompany.Id);                               
            }
            catch (Exception)
            {                
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [AllowAnonymous]
        [HttpPost("Search")]
        public async Task<ActionResult<Company>> Search([FromBody]SearchQuery searchQuery)
        {
                var companies = _repository.Company.SearchCompany(searchQuery);
                var companiesResult = _mapper.Map<IEnumerable<CompanyDto>>(companies);

                var response = new Response(companiesResult);
                return StatusCode(StatusCodes.Status200OK, response);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.        
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> PutCompany(long id, [FromBody]CompanyForUpdateDto company)
        {
            try
            {
                if (company == null)
                {
                    return BadRequest("Company object is null");
                }
                else if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                var companyEntity = await _repository.Company.GetCompanyByIdAsync(id);

                if (companyEntity == null)
                {
                    return NotFound();
                }

                _mapper.Map(company, companyEntity);
                _repository.Company.UpdateCompany(companyEntity);
                await _repository.SaveAsync();

                return StatusCode(StatusCodes.Status200OK, "Company updated");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE: api/Companies/        
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Company>> DeleteCompany(long id)
        {
            try
            {
                var company = await _repository.Company.GetCompanyByIdAsync(id);

                if (company == null)
                {
                    return NotFound();
                }

                _repository.Company.DeleteCompany(company);
                await _repository.SaveAsync();

                return StatusCode(StatusCodes.Status200OK, "Company deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}