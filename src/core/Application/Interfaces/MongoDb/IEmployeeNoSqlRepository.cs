using Domain.Entities;

namespace Application.Interfaces.MongoDb;

public interface IEmployeeNoSqlRepository
{
    Task AddEmployee(Employee employee);
}
