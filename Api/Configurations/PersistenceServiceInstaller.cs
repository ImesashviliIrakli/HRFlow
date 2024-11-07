
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories;

namespace Api.Configurations;

public class PersistenceServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>
        (
            options =>
            {
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                options.UseNpgsql
                (
                    //configuration["PostgreConnection"]
                    configuration.GetConnectionString("POSTGRES_CONNECTION_STRING")
                );
            }
        );

        // Service Registration
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<ILeaveRepository, LeaveRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
