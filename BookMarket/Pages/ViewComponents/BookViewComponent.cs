using BookM.ClientQueries.Model.Book.Books;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Pages.ViewComponents
{
    
    public class BookViewComponent:ViewComponent
    {

        private readonly IBookQueries _bookQueries;
        public BookViewComponent(IBookQueries bookQueries)
        {
            _bookQueries = bookQueries;
        }

        public IViewComponentResult Invoke()
        {
            var book = _bookQueries.GetAll();

            return View(book);
        }

    }
}
