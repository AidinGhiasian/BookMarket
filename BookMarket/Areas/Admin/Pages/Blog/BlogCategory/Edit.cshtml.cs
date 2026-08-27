using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogMInfrastructureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Blog.BlogCategory
{
    public class EditModel : PageModel
    {
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public EditModel(IBlogCategoryApplication blogCategoryApplication)
        {
            _blogCategoryApplication = blogCategoryApplication;
        }
        public EditBlogCategoryViewModel Category { get; set; }

        [NeedsPermission(BlogPermission.EditCategoryBlog)]
        public void OnGet(int id)
        {
            Category = _blogCategoryApplication.GetDetail(id);
        }
        public IActionResult OnPost(EditBlogCategoryViewModel command)
        {
            var result = _blogCategoryApplication.Edit(command);
            if (result==false)
            {
                TempData["failed"] = "بروزرسانی انجام نشد !!!!";
            }

            return Redirect("./BlogCategoryIndex");
        }
    }
}
