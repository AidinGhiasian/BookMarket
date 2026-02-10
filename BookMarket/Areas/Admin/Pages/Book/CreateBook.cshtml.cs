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
        public void OnGet()
        {
            
        }
        public void OnGetCategory()
        {
            books.BookCategories = _bookCategoryApplication.GetAll();
        }
        public void OnPost(BookM.Application.Contacts.BooksApplication.CreateViewModel command)
        {
            _bookApplication.Create(command);
            Redirect("./Admin/AdminIndex");
            TempData["success"] = "کتاب با موفقیت ثبت شد.";
        }
    }
}
