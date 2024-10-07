using Application.Models.NoSqlDocuments;

namespace Application.Interfaces.MongoDb;

public interface IEmployeeNoSqlRepository
{
    Task<List<EmployeeDocument>> GetEmployees();
    Task<EmployeeDocument> GetEmployeeByIdAsync(Guid employeeId);
    Task AddEmployeeAsync(EmployeeDocument employee);
    Task UpdateEmployeeDetailsAsync(EmployeeDocument employee);
    Task DeleteEmployeeAsync(EmployeeDocument employee);

}
