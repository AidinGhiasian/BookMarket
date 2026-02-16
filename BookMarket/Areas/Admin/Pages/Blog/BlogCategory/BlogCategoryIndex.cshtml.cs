using BlogM.Application.Contacts.BlogCategoryApplication;
using BlogM.Application.Contacts.PostApplication;
using BookM.Domain.Book.AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGet()
        {
            BlogCategories = _blogCategoryApplication.GetAll();
        }
    }
}
