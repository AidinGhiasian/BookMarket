using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    [Authorize(Roles = "Admin")]
    public class BookCategoryIndexModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public BookCategoryIndexModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }
        public List<BookCategoryViewModel> BookCategories { get; set; } = new();

        public void OnGet()
        {
            BookCategories = _bookCategoryApplication.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            try
            {
                if (!_bookCategoryApplication.Delete(id))
                    TempData["Error"] = "دسته‌بندی پیدا نشد.";
                else
                    TempData["success"] = "دسته‌بندی حذف شد.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToPage();
        }
    }
}
