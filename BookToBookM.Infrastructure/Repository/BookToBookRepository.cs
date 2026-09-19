using BookToBook.AD;
using BookToBookM.Domain.BookToBook.AD;
using BookToBookM.Infrastructure.EFCore;
using Microsoft.Isam.Esent.Interop;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookToBookM.Infrastructure.Repository
{
    public class BookToBookRepository : RepositoryBase<BookToBookItem>, IBookToBookRepository
    {
        private readonly BookToBookDbContext _dbContext;
        public BookToBookRepository(BookToBookDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
        public OperationResult Create(BookToBookItem item)
        {
            OperationResult result = new OperationResult();
            _dbContext.BookToBookItems.Add(item);
            return result.IsSuccess();

        }

        public OperationResult Delete(BookToBookItem item)
        {
            OperationResult result = new OperationResult();
            var exchangeBook = _dbContext.BookToBookItems.FirstOrDefault(x => x.Id == item.Id);
            _dbContext.BookToBookItems.Remove(exchangeBook);
            return result.IsSuccess();


        }
    }
}
