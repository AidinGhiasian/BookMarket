using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Model;

namespace BookM.Infrastructure.EFCore.Repository
{
    public class BookRepository : RepositoryBase<Books>, IBookRepository
    {
        private readonly BookDbContext _bookdbcontext;
        private readonly IFileUploader _fileUploader;

        public BookRepository(BookDbContext bookDbContext, IFileUploader fileUploader) : base(bookDbContext)
        {
            _fileUploader = fileUploader;
            _bookdbcontext = bookDbContext;
        }
        public void Create(Books books)
        {
            _bookdbcontext.Books.Add(books);
            _bookdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var DB = _bookdbcontext.Books.Find(id);
            if (DB != null)
            {
                _bookdbcontext.Books.Remove(DB);
                _bookdbcontext.SaveChanges();
            }
        }

        public Books Getby(string Title)
        {
            return _bookdbcontext.Books.FirstOrDefault(x => x.BookTitle == Title);
        }

        public List<Books> GetBy(string BookTitle)
        {
           return _bookdbcontext.Books.Where(x=>x.BookTitle == BookTitle).ToList();
        }

        public Books? GetById(int id)
        {
            return _bookdbcontext.Books.FirstOrDefault(x => x.Id == id);
        }

        public async Task Updateby(Books book)
        {
            var EB = _bookdbcontext.Books.FirstOrDefault(x => x.Id == book.Id);
            if (EB != null)
            {
                EB.Edit(book.Picture, book.BookTitle, book.Writer
                    , book.Publisher, book.CategoryId
                    , book.IsAvailable, book.Price,book.ShortDescription);
               await _bookdbcontext.SaveChangesAsync();
            }
        }
    }
}
