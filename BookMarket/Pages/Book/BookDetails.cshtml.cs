using BookM.ClientQueries.Model.Book.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Book
{
    public class BookDetailsModel : PageModel
    {
        private readonly IBookQueries _bookQueries;
        public BookDetailsModel(IBookQueries bookQueries)
        {
            _bookQueries = bookQueries;
        }
        public BookQueryViewModel Book { get; set; }
        public void OnGet(int id)
        {
            Book = _bookQueries.GetDetailInfo(id);
        }
    }
}
