using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Pages.ViewComponents
{
    public class BookCategoryMenuViewComponent:ViewComponent
    {
        private readonly IBookCategoryQuery _bookCategoryQuery;
        public BookCategoryMenuViewComponent(IBookCategoryQuery bookCategoryQuery)
        {
            _bookCategoryQuery = bookCategoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            var category = _bookCategoryQuery.GetAll();
            return View(category);
        }
    }
}
