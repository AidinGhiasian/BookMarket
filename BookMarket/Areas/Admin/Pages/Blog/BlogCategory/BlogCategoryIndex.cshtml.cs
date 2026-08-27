using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogM.Application.Contracts.PostApplication;
using BlogMInfrastructureConfiguration.Permission;
using BookM.Domain.Book.AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Blog.BlogCategory
{
    public class BlogCategoryIndexModel : PageModel
    {
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public BlogCategoryIndexModel(IBlogCategoryApplication blogCategoryApplication)
        {
            _blogCategoryApplication = blogCategoryApplication;
        }
        public List<BlogCategoryViewModel> BlogCategories { get; set; }

        [NeedsPermission(BlogPermission.ListCategoryBlog)]
        public void OnGet()
        {
            BlogCategories = _blogCategoryApplication.GetAll();
        }

    }
}
