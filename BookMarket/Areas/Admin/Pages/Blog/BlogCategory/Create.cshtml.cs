using BlogM.Application.Contacts.BlogCategoryApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog.BlogCategory
{
    public class CreateModel : PageModel
    {
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public CreateModel(IBlogCategoryApplication blogCategoryApplication)
        {
            _blogCategoryApplication = blogCategoryApplication;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(CreateBlogCategoryViewModel command)
        {
          var result=  _blogCategoryApplication.Create(command);
            if (result==false)
            {
                TempData["failed"] = "ثبت انجام نشد";
            }
            return Redirect("./BlogCategory/BlogCategoryIndex");

        }
    }
}
