using BookToBook.AD;
using Microsoft.EntityFrameworkCore;

namespace BookToBookM.Infrastructure.EFCore
{
    public class BookToBookDbContext : DbContext
    {
        public BookToBookDbContext(DbContextOptions<BookToBookDbContext> options): base(options)
        {
        }

        public DbSet<BookToBookItem> BookToBookItems { get; set; }
    }
}
