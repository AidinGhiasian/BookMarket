using AccountM.Application.Contacts.AccountApplication;
using BookM.Application.Contacts.BooksApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookMarket.Pages
{
    public class CreateBookModel : PageModel
    {
        private readonly IBookApplication _bookApplicarion;
        public CreateBookModel(IBookApplication bookApplication)
        {
            bookApplication = _bookApplicarion;      
        }
        public void OnGet()
        {

        }
        public void OnPost(BookM.Application.Contacts.BooksApplication.CreateViewModel command)
        {
            _bookApplicarion.Create(command);
            TempData["BookSuccess"] = "???? ???? ?? ?????? ??? ??...";
        }
    }
}
