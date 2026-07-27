using AccountManagement.Domain.RoleAgg;
using AM.Domain.Account.AD;
using AccountM.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AccountM.Infrastructure.EFCore
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class AccountDbContextFactory : IDesignTimeDbContextFactory<AccountDbContext>
    {
        public AccountDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AccountDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=.;Database=BookMarket;Integrated Security=True;TrustServerCertificate=True;");
            return new AccountDbContext(optionsBuilder.Options);
        }
    }
}
