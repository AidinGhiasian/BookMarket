using BookM.ClientQueries.Model.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public List<PostQueryViewModel> Blogs { get; set; } = new();
        public List<PostQueryViewModel> BlogsWithCategory { get; set; } = new();
        public List<BlogCategoryQueryViewModel> Categories { get; set; } = new();

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
            if (id == null || id == 0)
                Blogs = _postQueries.GetAll();
            else
                BlogsWithCategory = _postQueries.GetAllBlogWithCategory(id);
        }
    }
}
