using AccountM.Infrastructure.EFCore;
using Book.Infrastructure.EFCore;
using BookM.ClientQueries.Model.Account;
using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Evant;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Model.Book.Books;
using BookM.ClientQueries.Queries;
using BookM.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Configuration
{
    public class BookMClientQueriesConfigurationBootStrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
          
          
        }
    }
}
