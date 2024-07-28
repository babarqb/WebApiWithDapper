using System.Data;
using Dapper;
using WebApiWithDapper.Context;
using WebApiWithDapper.Contracts;
using WebApiWithDapper.Dto;
using WebApiWithDapper.Entities;

namespace WebApiWithDapper.Repository;

public class CompanyRepository(DapperContext dapperContext) : ICompanyRepository
{
    // private readonly DapperContext _dapperContext = dapperContext;
    public async Task<IEnumerable<Company>> GetCompaniesAsync()
    {
        var query = "SELECT * FROM Companies";

        using (var connection = dapperContext.CreateConnection())
        {
            var companies = await connection.QueryAsync<Company>(query);
            return companies.ToList();
        }
    }

    public async Task<Company> GetCompanyAsync(int id)
    {
        var query = "SELECT * FROM Companies WHERE Id = @Id";

        using (var connection = dapperContext.CreateConnection())
        {
            var company = await connection.QueryFirstOrDefaultAsync<Company>(query, new { Id = id });
            return company;
        }
    }

    public async Task<Company> CreateCompanyAsync(CompanyForCreationDto company)
    {
        var query = "INSERT INTO Companies (Name, Address, Website,Email,Phone) VALUES (@Name, @Address, @Website,@Email,@Phone) RETURNING Id";
        var parameters = new DynamicParameters();
        parameters.Add("Name", company.Name, DbType.String);
        parameters.Add("Address", company.Address, DbType.String);
        parameters.Add("Website", company.Website, DbType.String);
        parameters.Add("Email", company.Email, DbType.String);
        parameters.Add("Phone", company.Phone, DbType.String);

        using (var connection = dapperContext.CreateConnection())
        {
            var id = await connection.QuerySingleAsync<int>(query, parameters);
            var createComany = new Company()
            {
                Id = id,
                Name = company.Name,
                Address = company.Address,
                Website = company.Website,
                Email = company.Email,
                Phone = company.Phone
            };
            return createComany;
        }
    }
}