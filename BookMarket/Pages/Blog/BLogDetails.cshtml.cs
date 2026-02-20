using BlogM.Application.Contracts.PostApplication;
using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Post;
using BookM.ClientQueries.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    public class BLogDetailsModel : PageModel
    {
        private readonly IPostQueries _postQueries;
        public PostQueryViewModel Post { get; set; }

      
        public BLogDetailsModel(IPostQueries postQueries)
        {
           _postQueries = postQueries;
        }
        public void OnGet(int id)
        {
            Post = _postQueries.GetDetail(id);
        }
    }
}
