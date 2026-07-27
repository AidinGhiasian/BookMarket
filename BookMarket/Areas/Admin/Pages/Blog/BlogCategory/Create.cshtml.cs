using BlogM.Application.Contracts.BlogCategoryApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog.BlogCategory
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public CreateModel(IBlogCategoryApplication blogCategoryApplication)
        {
            _blogCategoryApplication = blogCategoryApplication;
        }

        public void OnGet() { }

        public IActionResult OnPost(CreateBlogCategoryViewModel command)
        {
            if (!ModelState.IsValid) return Page();
            var result = _blogCategoryApplication.Create(command);
            if (result.Failure)
            {
                TempData["failed"] = result.Message;
                return Page();
            }
            TempData["success"] = "دسته‌بندی با موفقیت ایجاد شد.";
            return RedirectToPage("./BlogCategoryIndex");
        }
    }
}
