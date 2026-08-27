using AccountMInfrastructureConfiguration.Permisions;
using BlogM.Application.Contracts.PostApplication;
using BlogMInfrastructureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        public IndexModel(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }
        public List<PostViewModel> Blogs { get; set; }

        [NeedsPermission(BlogPermission.ListPost)]
        public void OnGet()
        {
            Blogs = _postApplication.GetAll();
        }
        public IActionResult OnGetDelete(int id)
        {
            _postApplication.Delete(id);
             TempData["deleted"] = "مقاله با موفقیت حذف شد.";
            return RedirectToPage("./AdminIndex");
        }
    }
}
