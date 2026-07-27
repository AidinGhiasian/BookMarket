using BookM.ClientQueries.Model.Book.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public List<BookQueryViewModel> Books { get; set; } = new();
        private readonly IBookQueries _bookQueries;

        public IndexModel(IBookQueries bookQueries)
        {
            _bookQueries = bookQueries;
        }

        public void OnGet()
        {
            Books = _bookQueries.GetAll();
        }

        public IActionResult OnPost(string title)
        {
            return RedirectToPage("/Search/Index", new { title });
        }
    }
}
