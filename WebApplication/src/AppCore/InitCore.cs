using AppCore.Interfaces;
using AppCore.Managers;
using AppCore.Models;
using AutoMapper;
using DataAccessLayer;
using Microsoft.Extensions.DependencyInjection;

namespace AppCore
{
    public static class InitCore
    {
        public static void RegisterCoreServices(this IServiceCollection services)
        {
            services.RegisterDataAccessLayerServices();

            services.AddScoped<IRouteManager, RouteManager>();
            services.AddScoped<BaseRouteCalculator>();
            services.AddScoped<AdvancedRouteCalculator>();
            services.AddScoped<RouteCalculatorFactory>();
            services.AddScoped<TSP.TSP>();

            ConfigureMapper(services);
        }

        private static void ConfigureMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, TSPEngine.City>()
                    .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                    .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Latitude))
                    .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName)).ReverseMap();
            });

            services.AddSingleton(config.CreateMapper());
        }
    }
}