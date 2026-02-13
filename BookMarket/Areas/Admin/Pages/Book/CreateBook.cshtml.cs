using AccountM.Application.Contacts.AccountApplication;
using BookM.Application.Contacts.BooksApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookM.Application.Contacts;
using BookM.Application.Contacts.BooksCategoryApplication;
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
        public BookM.Application.Contacts.BooksApplication.CreateViewModel books { get; set; }
        public List<BookCategoryViewModel> BookCategories { get; set; }
        public void OnGet()
        {
            BookCategories = _bookCategoryApplication.GetAll();

        }
     
        public IActionResult OnPost(BookM.Application.Contacts.BooksApplication.CreateViewModel command)
        {
            _bookApplication.Create(command);
            TempData["success"] = "کتاب با موفقیت ثبت شد.";
          return  Redirect("./Admin/AdminIndex");
          
        }
    }
}
