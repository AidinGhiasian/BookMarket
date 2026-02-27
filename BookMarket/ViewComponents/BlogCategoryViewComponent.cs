using BookM.ClientQueries.Model.Blog.Categores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace BookMarket.ViewComponents
{
    public class BlogCategoryViewComponent:ViewComponent
    {
        private readonly IBlogCategoryQueries _blogCategoryQueries;
        public BlogCategoryViewComponent(IBlogCategoryQueries blogCategoryQueries)
        {
            _blogCategoryQueries=blogCategoryQueries;
        }

        public IViewComponentResult Invoke()
        {
            var category=_blogCategoryQueries.GetAll().Take(10).ToList();
            return View(category);
        }
    }
}
