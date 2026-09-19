using DiscountManegment.Domain.ColleagueDiscountbtAgg;
using DiscountManegment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EFCore
{
    public class DiscountContext:DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> options):base(options)
        {
            
        }
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<Colleague> Colleagues { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscount).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
