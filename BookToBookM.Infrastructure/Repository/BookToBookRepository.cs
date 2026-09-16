using BookToBook.AD;
using BookToBookM.Domain.BookToBook.AD;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookToBookM.Infrastructure.Repository
{
    public class BookToBookRepository : IBookToBookRepository
    {
        public OperationResult Create(BookToBookItem item)
        {
            throw new NotImplementedException();
        }

        public OperationResult Delete(BookToBookItem item)
        {
            throw new NotImplementedException();
        }

        public List<BookToBookItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<BookToBookItem?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(BookToBookItem item)
        {
            throw new NotImplementedException();
        }
    }
}
