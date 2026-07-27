using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogM.Application.Contracts.PostApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    [Authorize(Roles = "Admin")]
    public class CreateBlogModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        private readonly IBlogCategoryApplication _blogCategoryApplication;

        public CreateBlogModel(IPostApplication postApplication, IBlogCategoryApplication blogCategoryApplication)
        {
            _postApplication = postApplication;
            _blogCategoryApplication = blogCategoryApplication;
        }

        [BindProperty] public CreateViewModel? Blogs { get; set; }
        public List<BlogCategoryViewModel> BlogCategories { get; set; } = new();

        public void OnGet()
        {
            BlogCategories = _blogCategoryApplication.GetAll();
        }

        public IActionResult OnPost(CreateViewModel command)
        {
            if (!ModelState.IsValid)
            {
                BlogCategories = _blogCategoryApplication.GetAll();
                return Page();
            }
            try
            {
                _postApplication.create(command);
                TempData["success"] = "مقاله با موفقیت ثبت شد.";
                return RedirectToPage("./AdminIndex");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                BlogCategories = _blogCategoryApplication.GetAll();
                return Page();
            }
        }
    }
}
