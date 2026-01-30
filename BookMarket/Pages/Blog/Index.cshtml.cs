
using BlogM.Application.Contacts.PostApplication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    public class IndexModel : PageModel
    {

        public List<BlogM.Application.Contacts.PostApplication.PostViewModel> Blogs { get; set; }

        private readonly IPostApplication _postApplication;
        public IndexModel(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }



        public void OnGet()
        {
            Blogs = _postApplication.GetAll();
            if(Blogs.Count==0)
            {
                TempData["information"] = "هیچ مقاله ای وجود ندارد...";
            }
        }

       
    }
}
