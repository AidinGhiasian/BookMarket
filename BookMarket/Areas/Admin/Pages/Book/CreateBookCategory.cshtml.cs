using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    [Authorize(Roles = "Admin")]
    public class CreateBookCategoryModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public CreateBookCategoryModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }

        [BindProperty] public BookCategoryCreateViewModel? Category { get; set; }
        public void OnGet() { }

        public IActionResult OnPost(BookCategoryCreateViewModel command)
        {
            if (!ModelState.IsValid) return Page();
            try
            {
                _bookCategoryApplication.Create(command);
                TempData["success"] = "دسته‌بندی با موفقیت ایجاد شد.";
                return RedirectToPage("./BookCategoryIndex");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Page();
            }
        }
    }
}
