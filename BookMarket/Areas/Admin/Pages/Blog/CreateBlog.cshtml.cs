using BlogM.Application;
using BlogM.Application.Contacts.PostApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    public class CreateBlogModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        public CreateBlogModel(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }
        public void OnGet()
        {
        }
        public void OnPost(CreateViewModel command) 
        {
         _postApplication.create(command);
                TempData["success"] = "مقاله با موفقیت ثبت شد.";
            Redirect("./AdminIndex");
        }
    }
}
