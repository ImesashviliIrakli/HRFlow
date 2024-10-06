using Application.Interfaces.MongoDb;
using Domain.Entities;
using MongoDb.Persistance.Data;

namespace MongoDb.Persistance.Repositories;

public class EmployeeNoSqlRepository : IEmployeeNoSqlRepository
{
    private readonly MongoDbContext _context;
    public EmployeeNoSqlRepository(MongoDbContext context)
    {
        _context = context;
    }
    public async Task AddEmployee(Employee employee)
    {
        await _context.Employees.InsertOneAsync(employee);
    }
}
