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
using Microsoft.Extensions.Options;


namespace Book.Infrastructure.Configoration
{
    public class BookInfastructureConfigorationBootstraper
    {
        public  static void Configure(IServiceCollection services,string connectionString)
        {
            services.AddScoped<IBookApplication, BookAplication>();
            services.AddScoped<IBookRepository,BookRepository>();



            services.AddDbContext<BookDbContext>(option => option.UseSqlServer(connectionString));
        }
    }
}
