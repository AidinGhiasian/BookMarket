using AccountM.Application;
using AccountM.Application.Contracts.AccountApplication;
using AccountM.Application.Contracts.RoleApplication;
using AccountM.Infrastructure.EFCore;
using AccountM.Infrastructure.EFCore.Repository;
using AccountManagement.Domain.RoleAgg;
using AccountManagementConfiguration.Permission;
using AM.Domain.Account.AD;
using BookM.ClientQueries.Model.Account;
using BookM.ClientQueries.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMInfrastructureConfiguration
{
    public class AccountMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAccountApplication,AccountApplication>();
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<IRoleApplication,RoleApplication>();

            services.AddScoped<IAccountQueries, AccountQueries>();
            services.AddScoped<IPermissionExposer, AccountPermissionExposer>();



            services.AddDbContext<AccountDbContext>(options=>options.UseSqlServer(connectionString));
        }
    }
}
