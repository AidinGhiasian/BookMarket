using BlogM.Application.Contracts.BlogCategoryApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog.BlogCategory
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public EditModel(IBlogCategoryApplication blogCategoryApplication)
        {
            _blogCategoryApplication = blogCategoryApplication;
        }
        public EditBlogCategoryViewModel? Category { get; set; }

        public void OnGet(int id)
        {
            Category = _blogCategoryApplication.GetDetail(id);
        }

        public IActionResult OnPost(EditBlogCategoryViewModel command)
        {
            if (!ModelState.IsValid)
            {
                Category = command;
                return Page();
            }
            var result = _blogCategoryApplication.Edit(command);
            if (!result)
            {
                TempData["failed"] = "بروزرسانی انجام نشد!";
                Category = command;
                return Page();
            }
            TempData["success"] = "دسته‌بندی ویرایش شد.";
            return RedirectToPage("./BlogCategoryIndex");
        }
    }
}
