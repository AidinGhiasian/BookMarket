using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.SqlServer.Dac.Model;

namespace BookMarket.Areas.Admin.Pages.Book
{
    public class BookCategoryIndexModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public BookCategoryIndexModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }
        public List<BookCategoryViewModel> BookCategories { get; set; }
        public void OnGet()
        {
            BookCategories = _bookCategoryApplication.GetAll(); 
        }
        public IActionResult OnGetDelete(int id)
        {
            _bookCategoryApplication.Delete(id);
            return Redirect("./BookCategoryIndex");
        }
    }
}
