using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookMInfrastucureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Book.BookCategory
{
    public class CreateBookCategoryModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public CreateBookCategoryModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }


        public BookCategoryCreateViewModel category;

        [NeedsPermission(BookPermission.CreateBookCategory)]
        public void OnGet()
        {
        }

        public IActionResult OnPost(BookCategoryCreateViewModel command)
        {
            _bookCategoryApplication.Create(command);
            return Redirect("./BookCategoryIndex");
        }
    }
}
