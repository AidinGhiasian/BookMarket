using AccountM.Application.Contracts.AccountApplication;
using BookM.Application.Contracts.BooksApplication;
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
        public void OnPost(BookM.Application.Contracts.BooksApplication.CreateViewModel command)
        {
            _bookApplicarion.Create(command);
            TempData["BookSuccess"] = "???? ???? ?? ?????? ??? ??...";
        }
    }
}
