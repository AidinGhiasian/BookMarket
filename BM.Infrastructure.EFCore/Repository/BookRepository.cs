using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;

namespace BookM.Infrastructure.EFCore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly IBookCategoryRepository _bookcategoryRepository;
        private readonly BookDBContext _bookDBContext;
        public BookRepository(BookDBContext dbcontext,IBookCategoryRepository category )
        {
          _bookcategoryRepository=category;
            _bookDBContext=dbcontext;
        }
        public void Create(Books Create)
        {

            var b = new Books(Create.Picture, Create.BookTitle, Create.Writer, Create.Publisher, Create.CategoryId);
            _bookDBContext.Books.Add(b);
            _bookDBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _bookDBContext.Books.Remove(_bookDBContext.Books.Find(id));
            _bookDBContext.SaveChanges();
        }

        public Books Getby(string Title)
        {
            var b = _bookDBContext.Books.FirstOrDefault(b=>b.BookTitle == Title);
                return b;
        }

        public Books? GetById(int id)
        {
            return _bookDBContext.Books.FirstOrDefault(x=>x.Id == id); 
        }

        public void Updateby(Books book)
        {
            var b = GetById(book.Id);
            if (b != null)
            {
                b.Edit(b.Picture, b.BookTitle, b.Writer, b.Publisher, b.CategoryId, b.IsAvailable);
            _bookDBContext.Books.Update(b);
                _bookDBContext.SaveChanges();
            }
        }
    }
}
