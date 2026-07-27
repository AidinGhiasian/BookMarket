using BlogM.Application.Contracts.PostApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        public IndexModel(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }
        public List<PostViewModel> Blogs { get; set; } = new();

        public void OnGet()
        {
            Blogs = _postApplication.GetAll();
        }

        public IActionResult OnPostDelete(int id)
        {
            _postApplication.Delete(id);
            TempData["deleted"] = "مقاله با موفقیت حذف شد.";
            return RedirectToPage();
        }
    }
}
