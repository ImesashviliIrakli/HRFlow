using Application.Interfaces.MongoDb;
using Application.Models.NoSqlDocuments;
using MongoDb.Persistance.Data;
using MongoDB.Driver;

namespace MongoDb.Persistance.Repositories;

public class EmployeeNoSqlRepository : IEmployeeNoSqlRepository
{
    #region Injection
    private readonly MongoDbContext _context;
    public EmployeeNoSqlRepository(MongoDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Read
    public async Task<List<EmployeeDocument>> GetEmployees()
    {
        return await _context.Employees.Find(_ => true).ToListAsync();
    }
    public async Task<EmployeeDocument> GetEmployeeByIdAsync(Guid employeeId)
    {
        var filter = Builders<EmployeeDocument>.Filter.Eq(x => x.Id, employeeId);
        return await _context.Employees.Find(filter).FirstOrDefaultAsync();
    }
    #endregion

    #region Write
    public async Task AddEmployeeAsync(EmployeeDocument employee)
    {
        await _context.Employees.InsertOneAsync(employee);
    }

    public async Task UpdateEmployeeDetailsAsync(EmployeeDocument employee)
    {
        var filter = Builders<EmployeeDocument>.Filter.Eq(e => e.Id, employee.Id);

        var updateDefinition = Builders<EmployeeDocument>.Update
            .Set(e => e.FirstName, employee.FirstName)
            .Set(e => e.LastName, employee.LastName)
            .Set(e => e.Position, employee.Position)
            .Set(e => e.Address.Street, employee.Address.Street)
            .Set(e => e.Address.State, employee.Address.State)
            .Set(e => e.Address.City, employee.Address.City)
            .Set(e => e.Address.ZipCode, employee.Address.ZipCode);

        await _context.Employees.UpdateOneAsync(filter, updateDefinition);
    }

    public async Task DeleteEmployeeAsync(EmployeeDocument employee)
    {
        var filter = Builders<EmployeeDocument>.Filter.Eq(e => e.Id, employee.Id);

        await _context.Employees.DeleteOneAsync(filter);
    }
    #endregion
}
