using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Pages.ViewComponents
{
    public class BookCategoryViewComponent : ViewComponent
    {
        private readonly IBookCategoryQuery _categoryQueries;
        public BookCategoryViewComponent(IBookCategoryQuery categoryQueries)
        {
            _categoryQueries = categoryQueries;
        }
        public IViewComponentResult Invoke()
        {
            var category = _categoryQueries.GetAll();
            return View(category);
        }
    }
}
