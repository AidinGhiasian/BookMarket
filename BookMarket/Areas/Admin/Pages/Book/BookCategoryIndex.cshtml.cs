using BookM.Application.Contacts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGetDelete(int id)
        {
            _bookCategoryApplication.Delete(id);
        }
    }
}
