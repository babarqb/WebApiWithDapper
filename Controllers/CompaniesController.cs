using Microsoft.AspNetCore.Mvc;
using WebApiWithDapper.Contracts;
using WebApiWithDapper.Dto;

namespace WebApiWithDapper.Controllers;

[Route("api/companies")]
[ApiController]
public class CompaniesController(ICompanyRepository companyRepository) :Controller
{

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
       var companies = await companyRepository.GetCompaniesAsync();
       return Ok(companies);
    }
    
    [HttpGet("{id}",Name = "CompanyById")]
    public async Task<IActionResult> GetCompany(int id)
    {
       var company = await companyRepository.GetCompanyAsync(id);
       return Ok(company);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCompany([FromBody] CompanyForCreationDto company)
    {
       var createdCompany = await companyRepository.CreateCompanyAsync(company);
       return CreatedAtRoute("CompanyById", new {id = createdCompany.Id}, createdCompany);
    }
    
}