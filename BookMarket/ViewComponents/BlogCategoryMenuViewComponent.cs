using BookM.ClientQueries.Model.Blog.Categores;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.ViewComponents
{
    public class BlogCategoryMenuViewComponent:ViewComponent
    {
        private readonly IBlogCategoryQueries _blogCategoryQueries;
        public BlogCategoryMenuViewComponent(IBlogCategoryQueries blogCategoryQueries)
        {
            _blogCategoryQueries = blogCategoryQueries;
        }
        public IViewComponentResult Invoke()
        {
            var category = _blogCategoryQueries.GetAll();
            return View(category);
        }
    }
}
