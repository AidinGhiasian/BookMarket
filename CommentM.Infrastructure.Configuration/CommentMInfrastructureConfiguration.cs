using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentM.Application;
using CommentM.Application.Contacts;
using CommentM.Domain.Comment.AD;
using CommentM.Infrastructure.EFCore;
using CommentM.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentM.Infrastructure.Configuration
{
    public class CommentMInfrastructureConfiguration
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<ICommentApplication, CommentApplication>();


            services.AddDbContext<CommentDbContext>(options=>options.UseSqlServer(connectionString));
        }
          
    }
}
