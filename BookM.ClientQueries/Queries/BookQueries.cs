using BookM.Application.Contracts.BooksApplication;
using BookM.ClientQueries.Model.Book.Books;
using BookM.Domain.Book.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Queries
{
    public class BookQueries : IBookQueries
    {
        private readonly IBookApplication _bookApplication;
        public BookQueries(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }
        public List<BookQueryViewModel> GetAll()
        {
            return _bookApplication.GetAll().Select(book => new BookQueryViewModel
            {
                Id = book.Id,
                PictureFile = book.PictureFile,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                publisher = book.publisher,
                CategoryId = book.CategoryId,
                CreateDateTime = book.CreateDateTime,
                IsAvailable = book.IsAvailable,
                ShortDescription = book.ShortDescription,
                CategoryName = book.CategoryName
            }).ToList();
        }

        public BookQueryViewModel GetDetail(int id)
        {
            var book = _bookApplication.Getdetail(id);
            return new BookQueryViewModel
            {
                Id = book.Id,
                PictureFile = book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                publisher = book.Publisher,
                CategoryId = book.CategoryId,
                ShortDescription = book.shortdescription,
                CategoryName = book.Categorey,
            };
        }
    }
}
