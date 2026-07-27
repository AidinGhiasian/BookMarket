using BlogM.Application.Contracts.BlogCategoryApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog.BlogCategory
{
    [Authorize(Roles = "Admin")]
    public class BlogCategoryIndexModel : PageModel
    {
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public BlogCategoryIndexModel(IBlogCategoryApplication blogCategoryApplication)
        {
            _blogCategoryApplication = blogCategoryApplication;
        }
        public List<BlogCategoryViewModel> BlogCategories { get; set; } = new();

        public void OnGet()
        {
            BlogCategories = _blogCategoryApplication.GetAll();
        }
    }
}
