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
            var picturename=_fileUploader.UploadFileAsync(create.FileName, path);
            var upload = new  Books(picturename,create.BookTitle,create.Writer,create.Publisher,create.CategoryId);
            _bookRepository.Create(upload);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public Books? GetById(int id)
        {
            var bookget = _bookRepository.GetById(id);
            if(bookget != null)
            {
                return bookget;
            }
            return null;
        }

        public void Edit(EditViewModel update)
        {
          var upBooks=_bookRepository.GetById(update.Id);

            var PictureName = update.Picture;


            if (update.FileName != null)
            {
                _fileUploader.DeleteFileAsync(update.Picture);
                var path = "NewPicture";
                PictureName = _fileUploader.UploadFileAsync(update.FileName, path);
            }
            upBooks.Edit(PictureName,update.Picture, update.Writer,update.Publisher,update.CategoryId,update.status);

        }

        private BookViewModel map(Books book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                PictureFile=book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                publisher = book.Publisher,
                CategoryId = book.CategoryId,
                CreateDateTime = book.CreatetionDate,
                IsAvailable = book.IsAvailable,
            };
        }
    }
}
