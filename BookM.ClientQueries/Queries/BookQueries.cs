using BookM.Application.Contracts.BooksApplication;
using BookM.ClientQueries.Blog.Post;
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
                CategoryName = book.CategoryName,
                Price = book.Price
            }).ToList();
        }

        public List<BookQueryViewModel> GetAllBookWithCategory(int? categoryId)
        {
            var a= _bookApplication.GetAll()
             .Select(x => new BookQueryViewModel
             {
                 Id = x.Id,
                 PictureFile = x.PictureFile,
                 BookTitle = x.BookTitle,
                 ShortDescription = x.ShortDescription,
                 CategoryName = x.CategoryName,
                 IsAvailable = x.IsAvailable,
                 CategoryId = x.CategoryId,
                 Price = x.Price
             }).Where(x => x.CategoryId == categoryId).ToList();
            return a;
        }


        public BookQueryViewModel GetDetailInfo(int id)
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
                Price = book.Price
            };
        }

        public List<BookQueryViewModel> Search(string? title)
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
                CategoryName = book.CategoryName,
                Price = book.Price
            }).Where(x=>x.BookTitle.Contains(title)).ToList();
        }
    }
}
