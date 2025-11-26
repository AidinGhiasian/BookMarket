using AM.Domain.Account.AD;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure.EFCore
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

      
    }
}

