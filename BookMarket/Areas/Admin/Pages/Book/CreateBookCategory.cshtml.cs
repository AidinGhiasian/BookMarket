using BookM.Application.Contracts.BooksApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Book
{
    public class CreateBookCategoryModel : PageModel
    {
        private readonly IBookCategoryApplication _bookCategoryApplication;
        public CreateBookCategoryModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }


        public BookCategoryCreateViewModel category;
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
