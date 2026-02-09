using AccountM.Application.Contacts.AccountApplication;
using BookM.Application.Contacts.BooksApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookM.Application.Contacts;
namespace BookMarket.Areas.Admin.Pages.Book
{
    public class CreateBookModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        public CreateBookModel(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }
        public void OnGet()
        {
        }
        public BookM.Application.Contacts.BooksApplication.CreateViewModel book { get; set; }
        public void OnPost(BookM.Application.Contacts.BooksApplication.CreateViewModel command)
        {
            _bookApplication.Create(command);
            Redirect("./Admin/AdminIndex");
            TempData["success"] = "???? ?? ?????? ??? ??.";
        }
    }
}
