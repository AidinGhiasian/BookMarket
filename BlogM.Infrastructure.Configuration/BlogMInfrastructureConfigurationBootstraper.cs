using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using Blog.Infrastructure.EFCore.Repository;
using BlogM.Application;
using BlogM.Application.Contacts.PostApplication;
using Book.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogM.Infrastructure.Configuration
{
    public class BlogMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddScoped<IPostApplication,PostApplication>();


            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
