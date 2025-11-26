using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;

namespace BookM.Infrastructure.EFCore

{
    public class BookDBContext : DbContext
    {
        public BookDBContext(DbContextOptions<BookDBContext> options) : base(options)
        {
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Books>()
          .HasMany(b => b.BookCategories)
          .WithMany(c => c.Books);
        }

    }
}
