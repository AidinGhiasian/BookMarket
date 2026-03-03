
using BookM.ClientQueries.Blog.Categores;
using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Queries;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    public class IndexModel : PageModel
    {

        public List<PostQueryViewModel> Blogs { get; set; }
        public List<PostQueryViewModel> BlogsWithCategory { get; set; }
        public List<BlogCategoryQueryViewModel> Categories { get; set; }

        private readonly IBlogCategoryQueries _blogCategoryQueries;
        private readonly IPostQueries _postQueries;
        public IndexModel(IPostQueries postQueries, IBlogCategoryQueries blogCategoryQueries)
        {
            _postQueries = postQueries;
            _blogCategoryQueries = blogCategoryQueries;
        }
        public void OnGet(int? id)
        {
            Categories = _blogCategoryQueries.GetAll();
           
            if (id!=null&&id!=0)
            {
                BlogsWithCategory= _postQueries.GetAllBlogWithCategory(id);
            }
            else
            {
                Blogs = _postQueries.GetAll();
                if (Blogs.Count == 0)
                {
                    TempData["information"] = "هیچ مقاله ای وجود ندارد...";
                }
            }
        }

       
    }
}
