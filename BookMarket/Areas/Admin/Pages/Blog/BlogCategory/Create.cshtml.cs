using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogMInfrastructureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Blog.BlogCategory
{
    public class CreateModel : PageModel
    {
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public CreateModel(IBlogCategoryApplication blogCategoryApplication)
        {
            _blogCategoryApplication = blogCategoryApplication;
        }
        [NeedsPermission(BlogPermission.CreateCategoryBlog)]
        public void OnGet()
        {
        }
        public IActionResult OnPost(CreateBlogCategoryViewModel command)
        {
          var result=  _blogCategoryApplication.Create(command);
            if (result.Failure)
            {
                TempData["failed"] = result.Message;
            }
            return Redirect("./BlogCategoryIndex");

        }
    }
}
