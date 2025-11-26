using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookM.Infrastructure.EFCore.Repository
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        private readonly BookDBContext _dbContext;
        public BookCategoryRepository(BookDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(long id)
        {
            var d = _dbContext.BookCategories.FirstOrDefault(x => x.Id == id);
            if (d != null)
                _dbContext.BookCategories.Remove(d);
            _dbContext.SaveChanges();

        }

        public List<BookCategories> GetAll()
        {
            return _dbContext.BookCategories.ToList();
        }

        void IBookCategoryRepository.Create(BookCategories create)
        {
            var bk = new BookCategories(create.Name, create.Description);
            _dbContext.BookCategories.Add(bk);
            _dbContext.SaveChanges();
        }



        BookCategories? IBookCategoryRepository.GetById(long id)
        {
            var book = _dbContext.BookCategories.FirstOrDefault(b => b.Id == id);
            if (book != null) return book;
            return null;
        }

        void IBookCategoryRepository.Edit(BookCategories Update)
        {
            var bk = _dbContext.BookCategories.FirstOrDefault(b => b.Id == Update.Id);
            if (bk != null)
            {
                bk.UpdateCategory(Update.Name, Update.Description);
                _dbContext.BookCategories.Update(bk);
                _dbContext.SaveChanges();
            }
        }

    }
}
