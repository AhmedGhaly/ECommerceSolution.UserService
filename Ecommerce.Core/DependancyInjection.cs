using Ecommerce.Core.Services;
using Ecommerce.Core.ServicesContract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services) {

            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
