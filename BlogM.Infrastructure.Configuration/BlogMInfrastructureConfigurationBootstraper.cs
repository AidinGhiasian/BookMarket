using Blog.Domain.BlogAD;
using Blog.Domain.BlogCategoryAD;
using BlogM.Application;
using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogM.Application.Contracts.EventApplication;
using BlogM.Application.Contracts.PostApplication;
using BlogM.Infrastructure.EFCore.Migrations;
using BlogM.Infrastructure.EFCore.Repository;
using Book.Infrastructure.EFCore;
using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Evant;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMInfrastructureConfiguration
{
    public class BlogMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IBlogRepository,BlogRepository>();
            services.AddTransient<IPostApplication,PostApplication>();
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IEventApplication, EventApplication>();

            services.AddTransient<IBlogCategoryApplication,BlogCategoryApplication>();
            services.AddTransient<IBlogCategoryRepository,BlogCategoryRepository>();


            services.AddTransient<IBlogCategoryQueries, BlogCategoryQueries>();
            services.AddTransient<IPostQueries, PostQueries>();
            services.AddTransient<IEventQueries, EvantQuerirs>();


            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
