using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application;
using BookM.Application.Contacts.BooksApplication;
using BookM.Domain.Book.AD;
using BookM.Infrastructure.EFCore;
using BookM.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookM.Infrastucure.Configoration
{
    public class BookMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IBookApplication,BookApplication>();
            services.AddScoped<IBookRepository,BookRepository>();


            services.AddDbContext<BookDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
