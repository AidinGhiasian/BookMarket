using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.BlogAD;
using BlogM.Application;
using BlogM.Application.Contacts.EventApplication;
using BlogM.Application.Contacts.PostApplication;
using BlogM.Infrastructure.EFCore.Repository;
using Book.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BlogMInfrastructureConfiguration
{
    public class BlogMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBlogRepository,BlogRepository>();
            services.AddScoped<IPostApplication,PostApplication>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventApplication, EventApplication>();

            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
