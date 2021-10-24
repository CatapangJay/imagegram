using Imagegram.Application;
using Imagegram.Infrastructure;
using Imagegram.Persistence;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Imagegram.AzFunction.Startup))]
namespace Imagegram.AzFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.ConfigurePesistenceServices();
            builder.Services.ConfigureApplicationServices();
            builder.Services.ConfigureInfrastructureServices();
        }
    }
}
