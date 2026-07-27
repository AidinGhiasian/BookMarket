using BlogM.Application;
using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogM.Application.Contracts.EventApplication;
using BlogM.Application.Contracts.PostApplication;
using Book.Infrastructure.EFCore.Repository;
using Book.Infrastructure.EFCore;
using BookM.Application;
using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Event;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Model.Book.Books;
using BookM.ClientQueries.Queries;
using BookM.Domain.Book.AD;
using BookM.Infrastructure.EFCore;
using BookM.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookM.Infrastructure.Configuration
{
    public static class BookMInfrastructureConfigurationBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBookApplication, BookApplication>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            services.AddScoped<IBookCategoryApplication, BookCategoryApplication>();

            services.AddScoped<IBookQueries, BookQueries>();
            services.AddScoped<IBookCategoryQuery, BookCategoryQuery>();

            services.AddDbContext<BookDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Blog subsystem lives in Book.Infrastructure.EFCore (shared BlogDbContext).
            services.AddScoped<IPostApplication, PostApplication>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventApplication, EventApplication>();
            services.AddScoped<IBlogCategoryApplication, BlogCategoryApplication>();
            services.AddScoped<IBlogCategoryRepository, BlogCategoryRepository>();
            services.AddScoped<IBlogCategoryQueries, BlogCategoryQueries>();
            services.AddScoped<IPostQueries, PostQueries>();
            services.AddScoped<IEventQueries, EventQueries>();

            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
