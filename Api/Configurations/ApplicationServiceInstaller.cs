using Application.Behaviors;
using MediatR;

namespace Api.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));

        services.AddAutoMapper(Application.AssemblyReference.Assembly);
    }
}
