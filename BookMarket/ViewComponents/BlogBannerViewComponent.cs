using BookM.ClientQueries.Blog.Post;
using BookM.ClientQueries.Model.Blog.Post;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.ViewComponents
{
    public class BlogBannerViewComponent:ViewComponent
    {
        private readonly IPostQueries _postQueries;
        public BlogBannerViewComponent(IPostQueries postQueries)
        {
            _postQueries = postQueries;
        }
        public IViewComponentResult Invoke()
        {
            var posts=_postQueries.GetAll().Take(2).ToList();
            return View(posts);
        }
    }
}
