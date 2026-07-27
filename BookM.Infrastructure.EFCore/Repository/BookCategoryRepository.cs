using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;
using Services.Application;

namespace BookM.Infrastructure.EFCore.Repository
{
    public class BookCategoryRepository : RepositoryBase<BookCategories>, IBookCategoryRepository
    {
        private readonly BookDbContext _dbContext;
        public BookCategoryRepository(BookDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Deleted(int id)
        {
            var cat = _dbContext.BookCategories
                .Include(c => c.Books)
                .FirstOrDefault(c => c.Id == id);
            if (cat == null) return false;

            if (cat.Books != null && cat.Books.Any())
                throw new InvalidOperationException("این دسته‌بندی دارای کتاب است و قابل حذف نمی‌باشد.");

            _dbContext.BookCategories.Remove(cat);
            _dbContext.SaveChanges();
            return true;
        }

        public new List<BookCategories> GetAll()
            => _dbContext.BookCategories.Include(c => c.Books).ToList();

        public BookCategories? GetByName(string name)
            => _dbContext.BookCategories.FirstOrDefault(c => c.Name == name);

        public BookCategories? GetByIdIncludingBooks(int id)
            => _dbContext.BookCategories.Include(c => c.Books).FirstOrDefault(c => c.Id == id);
    }
}
