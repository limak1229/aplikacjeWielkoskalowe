using System.Collections.Generic;
using Algorythms.Implementations;
using Algorythms.Interfaces;
using AppCore.CalculatorCreators;
using AppCore.Interfaces;
using AppCore.RouteCalculators;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace AppCore
{
    public static class InitCore
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            services.RegisterDataAccessLayerServices();

            services.AddScoped<BaseRouteCalculator>();
            services.AddScoped<AdvancedRouteCalculator>();
            services.AddScoped<IJsonRouteCalculatorCreator, JsonRouteCalculatorCreator>();
            services.AddScoped<IAlgorythm<List<TSPEngine.City>>, Tsp>();
        }
    }
}