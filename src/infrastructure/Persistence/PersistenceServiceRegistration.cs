﻿using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuartion)
    {
        services.AddDbContext<AppDbContext>
        (
            options =>
            {
                options.UseSqlServer
                (
                    configuartion.GetConnectionString("DefaultConnection")
                );
            }
        );

        // Service Registration
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        return services;
    }
}