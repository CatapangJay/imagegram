using Imagegram.Application.Contracts.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Imagegram.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IImageUploader, LFSImageUploader>();

            return services;
        }
    }
}
