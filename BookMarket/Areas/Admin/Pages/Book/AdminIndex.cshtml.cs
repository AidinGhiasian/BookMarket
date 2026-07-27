using BookM.Application.Contracts.BooksApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    [Authorize(Roles = "Admin")]
    public class AdminIndexModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        public AdminIndexModel(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }
        public List<BookViewModel> Books { get; set; } = new();

        public void OnGet()
        {
            Books = _bookApplication.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            _bookApplication.Delete(id);
            TempData["danger"] = "کتاب با موفقیت حذف شد.";
            return RedirectToPage();
        }
    }
}
