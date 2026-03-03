using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IBookCategoryQuery _bookCategoryQuery;
        public MenuViewComponent(IBookCategoryQuery bookCategoryQuery)
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
