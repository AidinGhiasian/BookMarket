using BookM.Application.Contracts.BooksApplication;
using BookM.Domain.Book.AD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application.Contracts.BooksApplication;
using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Runtime.InteropServices;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.Infrastructure.EFCore;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.Excel;
using Services.Application;

namespace BookM.Application
{
    public class BookApplication : IBookApplication
    {
        private readonly IBookRepository _bookRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookApplication(IBookRepository bookRepository, IFileUploader fileUploader, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _fileUploader = fileUploader;
            _bookCategoryRepository = bookCategoryRepository;
        }
        public void Create(CreateViewModel create)
        {
            var path = "Book";

            var picturename = _fileUploader.UploadNewSize(create.FileName, path, 720);
            var npprice = create.Price;
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
            return _bookRepository.GetBy().Select(map).ToList();
        }

        public void Edit(EditViewModel update)
        {
            var upBooks = _bookRepository.GetById(update.Id);
            if (upBooks!=null)
            {
                var PictureName = update.Picture;

                var npprice = update.Price;

                if (update.FileName != null)
                {
                    _fileUploader.Delete(update.Picture);
                    var path = "Book";
                    PictureName = _fileUploader.UploadNewSize(update.FileName, path, 720);
                }
                upBooks.Edit(PictureName,update.BookTitle, update.Writer, update.Publisher, update.CategoryId, update.status, npprice, update.shortdescription);
                _bookRepository.SaveChanges();
            }

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
                ShortDescription = book.ShortDescription,
                Price = book.Price
            };
        }
        public BookCategoryViewModel mapcategory(BookCategories category)
        {
            return new BookCategoryViewModel
            {

                CategoryName = category.Name,
                Books = category.Books,
                CreatedAt = category.CreatedAt,
                Description = category.Description,
                Id = category.Id,

            };
        }

        public EditViewModel Getdetail(int id)
        {
            var book = _bookRepository.GetById(id);
            var categories = _bookCategoryRepository.GetAll().Select(mapcategory).ToList();
             return new EditViewModel
            {
                Id = book.Id,
                Picture = book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                Publisher = book.Publisher,
                CategoryId = book.CategoryId,
                shortdescription = book.ShortDescription,
                Categorey = book.Category.Name,
                Price = book.Price,
                BookCategories =categories
            };
        }
        public BookViewModel GetdetailInfo(int id)
        {
            var book = _bookRepository.GetById(id);
            return new BookViewModel
            {
                Id = book.Id,
                PictureFile = book.Picture,
                BookTitle = book.BookTitle,
                Writer = book.Writer,
                publisher = book.Publisher,
                CategoryId = book.CategoryId,
                ShortDescription = book.ShortDescription,
                CategoryName = book.Category.Name,
                Price = book.Price
            };
        }
        public List<Books> Search(string title)
        {
            return _bookRepository.GetBy(title);
        }
    }
}
