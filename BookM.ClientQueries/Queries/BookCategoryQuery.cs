using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.ClientQueries.Model.Book.Category;
using System.Collections.Generic;
using System.Linq;

namespace BookM.ClientQueries.Queries
{
    public class BookCategoryQuery : IBookCategoryQuery
    {
        private readonly IBookCategoryApplication _categoryApplication;

        public BookCategoryQuery(IBookCategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public List<BookCategoryQueryViewModel> GetAll()
        {
            return _categoryApplication.GetAll().Select(item => new BookCategoryQueryViewModel
            {
                Id = item.Id,
                CategoryName = item.CategoryName,
                Description = item.Description,
                Picture = item.Picture,
                CreatedAt = item.CreatedAt,
            }).ToList();
        }
    }
}
