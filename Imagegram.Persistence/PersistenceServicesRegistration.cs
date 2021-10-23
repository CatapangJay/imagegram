using Imagegram.Application.Persistence.Contracts;
using Imagegram.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imagegram.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePesistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ImagegramDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ImagegramConnectionString"))
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
