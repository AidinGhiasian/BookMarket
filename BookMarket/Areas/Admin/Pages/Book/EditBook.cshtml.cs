using BookM.Application.Contacts.BooksApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    public class EditBookModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        public EditBookModel(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }
        public EditViewModel Book { get; set; }
         
        public void OnGet(int id)
        {
            Book = _bookApplication.Getdetail(id);
        }
        public IActionResult OnPost(EditViewModel command)
        {
            _bookApplication.Edit(command);
            return RedirectToPage("./AdminIndex");
        }
    }
}
