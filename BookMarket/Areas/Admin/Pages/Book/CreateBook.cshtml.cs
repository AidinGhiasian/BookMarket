using AccountM.Application.Contracts.AccountApplication;
using BookM.Application.Contracts.BooksApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookM.Application.Contracts;
using BookM.Application.Contracts.BooksCategoryApplication;
namespace BookMarket.Areas.Admin.Pages.Book
{
    public class CreateBookModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        public readonly IBookCategoryApplication _bookCategoryApplication;
        public CreateBookModel(IBookApplication bookApplication,IBookCategoryApplication bookCategoryApplication)
        {
            _bookApplication = bookApplication;
            _bookCategoryApplication = bookCategoryApplication;
        }
        public BookM.Application.Contracts.BooksApplication.CreateViewModel books { get; set; }
        public List<BookCategoryViewModel> BookCategories { get; set; }
        public void OnGet()
        {
            BookCategories = _bookCategoryApplication.GetAll();
        }
     
        public IActionResult OnPost(BookM.Application.Contracts.BooksApplication.CreateViewModel command)
        {
            _bookApplication.Create(command);
            TempData["success"] = "کتاب با موفقیت ثبت شد.";
          return  Redirect("./AdminIndex");
          
        }
    }
}
