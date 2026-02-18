using BlogM.Application;
using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogM.Application.Contracts.PostApplication;
using BookM.Application.Contracts.BooksCategoryApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    public class CreateBlogModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public CreateBlogModel(IPostApplication postApplication, IBlogCategoryApplication blogCategoryApplication)
        {
            _postApplication = postApplication;
            _blogCategoryApplication = blogCategoryApplication;
        }
        public CreateViewModel Blogs { get; set; }
        public List<BlogCategoryViewModel> BlogCategories { get; set; }
        public void OnGet()
        {
            BlogCategories = _blogCategoryApplication.GetAll();
        }
        public IActionResult OnPost(CreateViewModel command)
        {
            _postApplication.create(command);
            TempData["success"] = "مقاله با موفقیت ثبت شد.";
            return Redirect("./AdminIndex");
        }
    }
}
