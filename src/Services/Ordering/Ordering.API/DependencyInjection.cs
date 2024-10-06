﻿using System.Runtime.CompilerServices;

namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return services;
        }

        public static WebApplication useApiServices(this WebApplication app)
        {
            return app;
        }
    }
}
