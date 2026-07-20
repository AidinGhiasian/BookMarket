using BookM.ClientQueries.Blog.Categores;
using BookM.ClientQueries.Model.Blog.Categores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace BookMarket.Pages.ViewComponents
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
            var categories = _blogCategoryQueries.GetAll();

            if (categories == null || !categories.Any())
                return Content("");

            return View(categories);
        }
    }
}
