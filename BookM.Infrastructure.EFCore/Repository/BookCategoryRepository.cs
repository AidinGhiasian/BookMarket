using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;
using Services;

namespace BookM.Infrastructure.EFCore.Repository
{
    public class BookCategoryRepository : RepositoryBase<BookCategories>, IBookCategoryRepository
    {
        private readonly BookDbContext _dbContext;
        public BookCategoryRepository(BookDbContext dbContext) :base(dbContext)
        {
          _dbContext = dbContext;
        }

        public bool Deleted(int id)
        {
            var cat = _dbContext.BookCategories.Find(id);
            _dbContext.BookCategories.Remove(cat);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
