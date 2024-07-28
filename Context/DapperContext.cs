using System.Data;
using Npgsql;

namespace WebApiWithDapper.Context;

public class DapperContext(IConfiguration configuration)
{
   private readonly string? _connectionString = configuration.GetConnectionString("PgSqlConnection");

   public IDbConnection CreateConnection() =>  new NpgsqlConnection(_connectionString);
   
}