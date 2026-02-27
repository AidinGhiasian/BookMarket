using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Application.Contracts.BooksApplication;
using BookM.Domain.Book.AD;

namespace BookM.Application.Contracts.BooksCategoryApplication
{
    public interface IBookCategoryQuery
    {
        List<BookCategoryQueryViewModel> GetAll();

    }
}

