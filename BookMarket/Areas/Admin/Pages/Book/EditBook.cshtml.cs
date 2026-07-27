using BookM.Application.Contracts.BooksApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    [Authorize(Roles = "Admin")]
    public class EditBookModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        private readonly IBookCategoryApplication _bookCategoryApplication;

        public EditBookModel(IBookApplication bookApplication, IBookCategoryApplication bookCategoryApplication)
        {
            _bookApplication = bookApplication;
            _bookCategoryApplication = bookCategoryApplication;
        }

        public EditViewModel? Book { get; set; }
        public List<BookCategoryViewModel> Categories { get; set; } = new();

        public void OnGet(int id)
        {
            Book = _bookApplication.Getdetail(id);
            Categories = _bookCategoryApplication.GetAll();
        }

        public IActionResult OnPost(EditViewModel command)
        {
            if (!ModelState.IsValid)
            {
                Categories = _bookCategoryApplication.GetAll();
                Book = command;
                return Page();
            }
            try
            {
                _bookApplication.Edit(command);
                TempData["success"] = "کتاب با موفقیت ویرایش شد.";
                return RedirectToPage("./AdminIndex");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                Categories = _bookCategoryApplication.GetAll();
                Book = command;
                return Page();
            }
        }
    }
}
