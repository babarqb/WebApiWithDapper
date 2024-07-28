namespace WebApiWithDapper.Entities;

public class Company
{
    public int Id{ get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    public string? Phone { get; set; }
    
    public List<Employee> Employees { get; set; }
}

public class Employee
{
    public int Id{ get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int CompanyId { get; set; }
}