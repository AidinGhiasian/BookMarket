using BookM.ClientQueries.Model.Blog.Post;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Areas.Admin.Pages.ViewComponents
{
    public class AdminBlogBannerViewComponent:ViewComponent
    {
        private readonly IPostQueries _postQueries;
        public AdminBlogBannerViewComponent(IPostQueries postQueries)
        {
            _postQueries=postQueries;
        }
        public IViewComponentResult Invoke()
        {
            var posts = _postQueries.GetAll().Take(3).ToList();
            return View(posts);
        }
    }
}
