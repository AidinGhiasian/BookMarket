using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application.Contacts.BooksApplication;
using BookM.Domain.Book.AD;

namespace BookM.Application.Contacts.BooksCategoryApplication
{
    public interface IBookCategoryApplication
    {

        public void Create(BookCategoryCreateViewModel create);
        public void Edit(BookCategoryEditViewModel update);
        public void Delete(int id);
        BookCategories? GetbyId(int id);


    }
}
