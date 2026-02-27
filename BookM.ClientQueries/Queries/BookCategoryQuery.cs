using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Queries
{
    public class BookCategoryQuery:IBookCategoryQuery
    {
        private readonly IBookCategoryApplication _categoryApplication;
        public BookCategoryQuery(IBookCategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public List<BookCategoryQueryViewModel> GetAll()
        {
           var category = _categoryApplication.GetAll();
            var list = new List<BookCategoryQueryViewModel>();
            foreach (var item in category)
            {
                list.Add(new BookCategoryQueryViewModel
                {
                    Id = item.Id,
                    CategoryName=item.CategoryName,
                    Description=item.Description,
                    Picture=item.Picture,
                    CreatedAt=item.CreatedAt,
                });
            }
            return list;
        }


    }
}
