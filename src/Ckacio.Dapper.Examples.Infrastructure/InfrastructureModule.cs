using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ckacio.Dapper.Examples.Infrastructure.Data.UoW;

namespace Ckacio.Dapper.Examples.Infrastructure
{
    public static class InfrastructureModule
    {
        public static void RegisterInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            var CommandTimeout = configuration.GetValue<int>("DatabaseDefaults:DefaultCommandTimeout");
            var ConnectionStringName = "Cartoon";
            var ConnDB = configuration.GetConnectionString(ConnectionStringName);
            UnitOfWorkConnectionStringPool.SetConnectionString(ConnectionStringName, ConnDB, CommandTimeout);
        }
    }
}
