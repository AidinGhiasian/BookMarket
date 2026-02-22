using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;

namespace BookM.Infrastructure.EFCore
{
    public class BookDbContext :DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Books>().HasOne(b => b.Category).WithMany(c => c.Books);
        }
    }

}
