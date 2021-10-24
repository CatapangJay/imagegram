using Imagegram.Application.Constants;
using Imagegram.Application.Contracts.Persistence;
using Imagegram.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Imagegram.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePesistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ImagegramDbContext>(options => 
                options.UseSqlServer(EnvironmentVariables.ConnectionString)
            );

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IImgramUserRepository, ImgramUserRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
