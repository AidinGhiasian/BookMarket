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
<<<<<<< HEAD
            return Redirect("./adminIndex");
=======
            return Redirect("./AdminIndex");
>>>>>>> 8b2c6dc79c5e112d8d2b22ef3e271e209d030e68
        }
    }
}
