using BookM.ClientQueries.Model.Account;
using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Evant;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Model.Book.Books;
using BookM.ClientQueries.Queries;
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
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IAccountQueries, AccountQueries>();
            services.AddScoped<IBlogCategoryQueries, BlogCategoryQueries>();
            services.AddScoped<IPostQueries, PostQueries>();
            services.AddScoped<IEventQueries, EvantQuerirs>();
            services.AddScoped<IBookQueries, BookQueries>();
        }
    }
}
