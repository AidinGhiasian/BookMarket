using BookM.Application.Contacts.BooksApplication;
using BookM.Domain.Book.AD;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application.Contacts.BooksApplication;
using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;
using Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookM.Application
{
    public class BookApplication : IBookApplication
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFileUploader _fileUploader;
        public BookApplication(IBookRepository bookRepository, IFileUploader fileUploader)
        {
            _bookRepository = bookRepository;
            _fileUploader = fileUploader;
        }
        public void Create(CreateViewModel create)
        {
            var path = "picture";
            var prefixprice = "تومان";
            var picturename = _fileUploader.UploadNewSize(create.FileName, path, 720);
            var npprice = create.Price + " " + prefixprice;
            var upload = new Books(picturename, create.BookTitle, create.Writer, create.Publisher, create.CategoryId, npprice, create.shortdescription);
            _bookRepository.Create(upload);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public Books? GetById(int id)
        {
            var bookget = _bookRepository.GetById(id);
            if (bookget != null)
            {
                return bookget;
            }
            return null;
        }
        public List<BookViewModel> GetAll()
        {
            var list = new List<BookViewModel>();
            var bookget = _bookRepository.GetAll();
            if (bookget != null)
            {
                foreach (var book in bookget)
                {
                    list.Add(map(book));
                }
            }
            return list;
        }
        public void Edit(EditViewModel update)
        {
            var upBooks = _bookRepository.GetById(update.Id);

            var PictureName = update.Picture;
            var prefixprice = "تومان";
            var npprice = update.Price + " " + prefixprice;
            if (update.FileName != null)
            {
                _fileUploader.Delete(update.Picture);
                var path = "NewPicture";
                PictureName = _fileUploader.UploadNewSize(update.FileName, path, 720);
            }
            upBooks.Edit(PictureName, update.Picture, update.Writer, update.Publisher, update.CategoryId, update.status, npprice, update.shortdescription);

        }

        private BookViewModel map(Books book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                PictureFile = book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                publisher = book.Publisher,
                CategoryId = book.CategoryId,
                CreateDateTime = book.CreatetionDate,
                IsAvailable = book.IsAvailable,
            };
        }

        public EditViewModel Getdetail(int id)
        {
            var book = _bookRepository.GetById(id);
            return new EditViewModel
            {
                Id = book.Id,
                Picture = book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                Publisher = book.Publisher,
                CategoryId = book.CategoryId,
                shortdescription = book.ShortDescription
            };
        }
    }
}
