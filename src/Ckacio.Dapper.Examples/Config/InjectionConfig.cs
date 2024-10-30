using Ckacio.Dapper.Examples.Core.Interfaces;
using Ckacio.Dapper.Examples.Core.Services;

namespace Ckacio.Dapper.Examples.Config
{
    public static class InjectionConfig
    {
        public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services) 
        {
            services.AddTransient<ICartoonService, CartoonService>();


            return services;
        }


    }
}
