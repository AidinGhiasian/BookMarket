using BookM.ClientQueries.Model.Book.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer.Dac.Model;

namespace BookMarket.Pages.ViewComponents
{
    public class BookBannerViewComponent:ViewComponent
    {
        private readonly IBookQueries _bookQueries;
        public BookBannerViewComponent(IBookQueries bookQueries)
        {
            _bookQueries = bookQueries;
        }
        public IViewComponentResult Invoke()
        {
            var book = _bookQueries.GetAll().Take(1).ToList()//.First();
            return View(book);
        }
    }
}
