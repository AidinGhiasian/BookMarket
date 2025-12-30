using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using AccountManagement.Domain.RoleAgg;
using AM.Domain.Account.AD;
using Microsoft.EntityFrameworkCore;

namespace AccountM.Infrastructure.EFCore
{
    public class AccountDbContext:DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext>options):base(options) { }
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
