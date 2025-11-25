using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services) {

            return services;
        }
    }
}
