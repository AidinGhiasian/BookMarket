using BookToBook.AD;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookToBookM.Domain.BookToBook.AD
{
    public interface IBookToBookRepository
    {
        public List<BookToBookItem?> GetById(long id);
        public List<BookToBookItem> GetAll();
        public OperationResult Create(BookToBookItem item);
        public OperationResult Update(BookToBookItem item);
        public OperationResult Delete(BookToBookItem item);
    }
}
