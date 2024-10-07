using Application.Models.NoSqlDocuments;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace MongoDb.Persistance.Data;

public class MongoDbContext : DbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IMongoDatabase database)
    {
        _database = database;
    }

    public IMongoCollection<EmployeeDocument> Employees => _database.GetCollection<EmployeeDocument>("employees");
}
