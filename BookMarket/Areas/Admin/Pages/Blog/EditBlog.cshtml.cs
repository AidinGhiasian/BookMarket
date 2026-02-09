using BlogM.Application.Contacts.PostApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    public class EditBlogModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        public EditBlogModel(IPostApplication postApplication)
        {
            _postApplication = postApplication;
        }
        public EditViewModel Blog { get; set; }
        public void OnGet(int id)
        {
            Blog = _postApplication.GetDetailes(id);
        }
        public IActionResult OnPost(EditViewModel command)
        {
          _postApplication.Update(command);
            return Redirect("/Admin/Blog");
        }
    }
}
