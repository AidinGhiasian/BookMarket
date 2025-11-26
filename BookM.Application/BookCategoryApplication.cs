using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application.Contacts.BooksApplication;
using BookM.Application.Contacts.BooksCategoryApplication;
using BookM.Domain.Book.AD;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookM.Application
{
    public class BookCategoryApplication : IBookCategoryApplication
    {
        private readonly IBookCategoryRepository _bookcategory;
        public BookCategoryApplication(IBookCategoryRepository bookcategory)
        {
            _bookcategory = bookcategory;
        }

        public void Create(BookCategoryCreateViewModel create)
        {
            var category = new BookCategories(create.CategoryName, create.Description);
            _bookcategory.Create(category);
        }

        public void Delete(int id)
        {
            _bookcategory.Delete(id);
        }



        public void Edit(BookCategoryEditViewModel update)
        {
            var category = _bookcategory.GetById(update.Id);
            if (category != null)
            {
                _bookcategory.Edit(category);
            }   
        }

        public BookCategories? GetbyId(int id)
        {
          var bookget = _bookcategory.GetById(id);
            if (bookget!=null)
            {
             return bookget;   
            }
            return null;
        }
    }
}
