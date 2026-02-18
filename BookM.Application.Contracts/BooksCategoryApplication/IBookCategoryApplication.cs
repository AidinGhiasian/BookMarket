using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application.Contracts.BooksApplication;
using BookM.Domain.Book.AD;

namespace BookM.Application.Contracts.BooksCategoryApplication
{
    public interface IBookCategoryApplication
    {

        public void Create(BookCategoryCreateViewModel create);
        public void Edit(BookCategoryEditViewModel update);
        public bool Delete(int id);
        BookCategories? GetbyId(int id);
        List<BookCategoryViewModel> GetAll();
        public BookCategoryEditViewModel GetById(int id);


    }
}
