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
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookdbcontext;
        private readonly FileUploader _fileUploader;

        public BookRepository(BookDbContext bookDbContext, FileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _bookdbcontext = bookDbContext;
        }
        public void Create(Books books)
        {
            var CB = _bookdbcontext.Books.Add(books);
            _bookdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var a = _bookdbcontext.Books.Find(id);
            if (a != null)
            {
                _bookdbcontext.Books.Remove(a);
            }
        }

        public Books Getby(string Title)
        {
            return _bookdbcontext.Books.FirstOrDefault(x => x.BookTitle == Title);
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
                    ,book.Publisher, book.CategoryId
                    , book.IsAvailable);
                await _bookdbcontext.SaveChangesAsync();
            }
        }
    }
}
