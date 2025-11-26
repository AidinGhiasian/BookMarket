using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application;
using BookM.Application.Contacts.BooksApplication;
using BookM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookM.Infrastructure.Configoration
{
    public class BMInfrastructureConfigorationBootstraper
    {
        public static void Configure(IServiceCollection service, string contectionstring)
        {
            service.AddScoped<IBookApplication, BookAplication>();
            service.AddScoped<IBookRepository>




            service.AddDbContext<BookDBContext>(x=>x.UseSqlServer(contectionstring));
        }
    }
}
