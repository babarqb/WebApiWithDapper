using WebApiWithDapper.Dto;
using WebApiWithDapper.Entities;

namespace WebApiWithDapper.Contracts;

public interface ICompanyRepository
{
    public Task<IEnumerable<Company>> GetCompaniesAsync();
    public Task<Company> GetCompanyAsync(int id);

    public Task<Company> CreateCompanyAsync(CompanyForCreationDto company);
    // public Task UpdateCompanyAsync(Company company);
    // public Task DeleteCompanyAsync(int id); 
}