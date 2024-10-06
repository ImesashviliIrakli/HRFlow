using Application.Interfaces.MongoDb;
using Microsoft.Extensions.Options;
using MongoDb.Persistance.Data;
using MongoDb.Persistance.Repositories;
using MongoDB.Driver;

namespace Api.Configurations;

public class MongoDbPersistenceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

        services.AddSingleton<MongoDbContext>(sp =>
        {
            var mongoDbSettings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            return new MongoDbContext(database);
        });

        services.AddScoped<IEmployeeNoSqlRepository, EmployeeNoSqlRepository>();
    }
}

public class MongoDbSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}