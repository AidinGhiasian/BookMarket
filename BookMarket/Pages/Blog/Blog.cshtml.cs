using BlogM.Application.Contracts.PostApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    public class BlogModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        public BlogModel(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }
        public void OnGet()
        {

        }
        public void OnPost(CreateViewModel command)
        {
           
            _postApplication.create(command);
            TempData["success"] = "وبلاگ جدید ثبت شد...";
        }
    }
}
