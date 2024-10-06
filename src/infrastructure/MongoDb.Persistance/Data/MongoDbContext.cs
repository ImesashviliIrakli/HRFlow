using Domain.Entities;
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

    public IMongoCollection<Employee> Employees => _database.GetCollection<Employee>("employees");
}
