using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountM.Application;
using AccountM.Application.Contacts.AccountApplication;
using AccountM.Infrastructure.EFCore;
using AccountM.Infrastructure.EFCore.Repository;
using AccountManagement.Domain.RoleAgg;
using AM.Domain.Account.AD;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountMInfrastructureConfiguration
{
    public class AccountMInfrastructureConfigurationBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAccountApplication,AccountApplication>();
            services.AddScoped<IAccountRepository,AccountRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();




            services.AddDbContext<AccountDbContext>(options=>options.UseSqlServer(connectionString));
        }
    }
}
