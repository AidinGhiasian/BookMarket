using BookM.ClientQueries.Model.Blog.Post;
using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.ViewComponents
{
    public class BlogViewComponent:ViewComponent
    {
        private readonly IPostQueries _postQueries;
        public BlogViewComponent( IPostQueries postQueries)
        {
            _postQueries = postQueries;
        }


        public IViewComponentResult Invoke()
        {
            var post = _postQueries.GetAll();
            return View(post);
                
        }
    }
}
