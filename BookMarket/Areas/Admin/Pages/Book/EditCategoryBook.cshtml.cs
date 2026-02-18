using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    public class EditCategoryBookModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public EditCategoryBookModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }


        public BookCategoryEditViewModel category;
        public void OnGet(int id)
        {
            category = _bookCategoryApplication.GetById(id);
        }

        public IActionResult OnPost(BookCategoryEditViewModel command)
        {
            _bookCategoryApplication.Edit(command);
            return Redirect("./BookCategoryIndex");
        }
    }
}
