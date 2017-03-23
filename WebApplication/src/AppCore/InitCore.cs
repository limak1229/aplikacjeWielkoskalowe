using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.Interfaces;
using AppCore.Managers;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace AppCore
{
    public static class InitCore
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            services.RegisterDataAccessLayerServices();

            services.AddScoped<ITestManager, TestManager>();
        }
    }
}
