using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    [Authorize(Roles = "Admin")]
    public class CreateBookModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        private readonly IBookCategoryApplication _bookCategoryApplication;

        public CreateBookModel(IBookApplication bookApplication, IBookCategoryApplication bookCategoryApplication)
        {
            _bookApplication = bookApplication;
            _bookCategoryApplication = bookCategoryApplication;
        }

        [BindProperty] public BookM.Application.Contracts.BooksApplication.CreateViewModel? Books { get; set; }
        public List<BookCategoryViewModel> BookCategories { get; set; } = new();

        public void OnGet()
        {
            BookCategories = _bookCategoryApplication.GetAll();
        }

        public IActionResult OnPost(BookM.Application.Contracts.BooksApplication.CreateViewModel command)
        {
            if (!ModelState.IsValid)
            {
                BookCategories = _bookCategoryApplication.GetAll();
                return Page();
            }
            try
            {
                _bookApplication.Create(command);
                TempData["success"] = "کتاب با موفقیت ثبت شد.";
                return RedirectToPage("./AdminIndex");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                BookCategories = _bookCategoryApplication.GetAll();
                return Page();
            }
        }
    }
}
