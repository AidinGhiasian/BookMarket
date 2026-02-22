
using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Post;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    public class IndexModel : PageModel
    {

        public List<PostQueryViewModel> Blogs { get; set; }
        private readonly IPostQueries _postQueries;
        public IndexModel(IPostQueries postQueries)
        {
            _postQueries = postQueries;
        }
        public void OnGet()
        {
            Blogs = _postQueries.GetAll();
            if(Blogs.Count==0)
            {
                TempData["information"] = "هیچ مقاله ای وجود ندارد...";
            }
        }

       
    }
}
