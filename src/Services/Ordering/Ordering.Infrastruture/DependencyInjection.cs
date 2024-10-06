﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastruture.Data;


namespace Ordering.Infrastruture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
