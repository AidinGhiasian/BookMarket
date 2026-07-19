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
            var categories = _bookCategoryQuery.GetAll();

            if (categories == null || !categories.Any())
                return Content("");

            return View(categories);
        }
    }
}
