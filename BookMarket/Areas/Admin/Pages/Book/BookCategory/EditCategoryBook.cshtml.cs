using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookMInfrastucureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Book.BookCategory
{
    public class EditCategoryBookModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public EditCategoryBookModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }


        public BookCategoryEditViewModel category;

        [NeedsPermission(BookPermission.EditBookCategory)]
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
