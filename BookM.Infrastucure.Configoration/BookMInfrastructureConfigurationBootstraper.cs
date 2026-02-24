using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book.Infrastructure.EFCore;
using BookM.Application;
using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.ClientQueries.Model.Book.Books;
using BookM.ClientQueries.Queries;
using BookM.Domain.Book.AD;
using BookM.Infrastructure.EFCore;
using BookM.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookMInfrastucureConfigoration
{
    public class BookMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBookApplication,BookApplication>();
            services.AddScoped<IBookRepository,BookRepository>();

            services.AddScoped<IBookCategoryRepository,BookCategoryRepository>();
            services.AddScoped<IBookCategoryApplication,BookCategoryApplication>();


            services.AddScoped<IBookQueries, BookQueries>();



            services.AddDbContext<BookDbContext>(options => 
            options.UseSqlServer(connectionString));
           
        }
    }
}
