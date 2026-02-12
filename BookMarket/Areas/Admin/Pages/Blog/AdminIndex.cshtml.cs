using BlogM.Application.Contacts.PostApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public void OnGet()
        {
            Blogs = _postApplication.GetAll();
        }
        public void OnGetDelete(int id)
        {
            _postApplication.Delete(id);
            TempData["deleted"] = "مقاله با موفقیت حذف شد.";
        }
    }
}
