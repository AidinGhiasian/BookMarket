using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    [Authorize(Roles = "Admin")]
    public class EditCategoryBookModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public EditCategoryBookModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }

        public BookCategoryEditViewModel? Category { get; set; }

        public void OnGet(int id)
        {
            Category = _bookCategoryApplication.GetById(id);
        }

        public IActionResult OnPost(BookCategoryEditViewModel command)
        {
            if (!ModelState.IsValid)
            {
                Category = command;
                return Page();
            }
            try
            {
                _bookCategoryApplication.Edit(command);
                TempData["success"] = "دسته‌بندی ویرایش شد.";
                return RedirectToPage("./BookCategoryIndex");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                Category = command;
                return Page();
            }
        }
    }
}
