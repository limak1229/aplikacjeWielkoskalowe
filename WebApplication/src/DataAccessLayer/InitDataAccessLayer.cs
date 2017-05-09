using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class InitDataAccessLayer
    {
        public static void RegisterDataAccessLayerServices(this IServiceCollection services)
        {
            services.AddScoped<ICalculatedRoutesRepository, CalculatedRoutesRepository>();
        }
    }
}
