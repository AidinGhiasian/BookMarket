using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using DiscountManegment.Application;
using DiscountManegment.Application.Contract.ColleagueDiscountApplication;
using DiscountManegment.Application.Contract.CustomerDiscountApplication;
using DiscountManegment.Configuration.Permissions;
using DiscountManegment.Domain.ColleagueDiscountbtAgg;
using DiscountManegment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Infrastructure;

namespace DiscountManegment.Configuration
{
    public class DiscountManagementBoostrapper
    {
        public static void ConfigurDiscount(IServiceCollection services, string contectionString)
        {
            services.AddScoped<ICustomerDiscountApplication, CoustomerDiscountApplication>();
            services.AddScoped<ICustomerDiscountRepository, CustomerDiscountRepository>();

            services.AddScoped<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            services.AddScoped<IColleagueDiscountRepository, ColleagueDiscountRepository>();

            services.AddScoped<IPermissionExposer, DiscountPermissionsExposer>();

            services.AddDbContext<DiscountContext>(x=>x.UseSqlServer(contectionString));
        }
    }
}
