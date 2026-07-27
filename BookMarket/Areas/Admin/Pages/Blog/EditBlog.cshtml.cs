using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogM.Application.Contracts.PostApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    [Authorize(Roles = "Admin")]
    public class EditBlogModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        private readonly IBlogCategoryApplication _blogCategoryApplication;

        public EditBlogModel(IPostApplication postApplication, IBlogCategoryApplication blogCategoryApplication)
        {
            _postApplication = postApplication;
            _blogCategoryApplication = blogCategoryApplication;
        }

        public EditViewModel? Blog { get; set; }
        public List<BlogCategoryViewModel> BlogCategories { get; set; } = new();

        public void OnGet(int id)
        {
            Blog = _postApplication.GetDetailes(id);
            BlogCategories = _blogCategoryApplication.GetAll();
        }

        public IActionResult OnPost(EditViewModel command)
        {
            if (!ModelState.IsValid)
            {
                BlogCategories = _blogCategoryApplication.GetAll();
                Blog = command;
                return Page();
            }
            try
            {
                _postApplication.Update(command);
                TempData["success"] = "مقاله ویرایش شد.";
                return RedirectToPage("./AdminIndex");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                BlogCategories = _blogCategoryApplication.GetAll();
                Blog = command;
                return Page();
            }
        }
    }
}
