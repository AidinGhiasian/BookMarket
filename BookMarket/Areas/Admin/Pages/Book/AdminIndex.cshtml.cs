using BookM.Application.Contacts.BooksApplication;
using BookM.Domain.Book.AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    public class AdminIndexModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        public AdminIndexModel(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }
        public List<BookViewModel> Books { get; set; }
        public void OnGet()
        {
            Books = _bookApplication.GetAll();
        }
        public IActionResult OnGetDelete(int id)
        {
            _bookApplication.Delete(id);
            return Redirect("./AdminIndex");
        }
    }
}
