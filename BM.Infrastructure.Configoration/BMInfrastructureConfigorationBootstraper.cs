using Blog.Domain.BlogAD;
using Blog.Infrastructure.EFCore.Repository;
using BlogM.Application;
using BlogM.Application.Contacts.PostApplication;
using BlogM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookM.Infrastructure.Configoration
{
    public class BMInfrastructureConfigorationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IPostApplication, PostApplication>();
            services.AddScoped<IBlogRepository,BlogRepository>();

            services.AddDbContext<BlogDBContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
