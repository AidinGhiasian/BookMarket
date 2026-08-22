using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.ClientQueries.Model.Comment;
using BookM.ClientQueries.Queries;
using CommentM.Application;
using CommentM.Application.Contracts;
using CommentM.Domain.Comment.AD;
using CommentM.Infrastructure.EFCore;
using CommentM.Infrastructure.EFCore.Repository;
using CommentMInfrastructureConfiguration.Permission;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Infrastructure;

namespace CommentMInfrastructureConfiguration
{
    public class CommentMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICommentRepository,CommentRepository>();
            services.AddScoped<ICommentApplication, CommentApplication>();

            services.AddScoped<ICommentQueries,CommentQueries>();

            services.AddScoped<IPermissionExposer,CommentPermissionExposer>();

            services.AddDbContext<CommentDbContext>(options=>options.UseSqlServer(connectionString));
        }
          
    }
}
