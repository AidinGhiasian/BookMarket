using BookM.ClientQueries.Model.Book.Books;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BookMarket.ViewComponents
{
    public class NewPrintBookViewComponent:ViewComponent
    {
        private readonly IBookQueries _bookQueries;
        public NewPrintBookViewComponent(IBookQueries bookQueries)
        {
            _bookQueries = bookQueries;
        }
        public IViewComponentResult Invoke()
        {
            var book = _bookQueries.GetAll().Take(2).ToList();
            return View(book);
        }
    }
}
