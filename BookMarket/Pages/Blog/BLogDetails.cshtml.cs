using BlogM.Application.Contacts.PostApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Blog
{
    public class BLogDetailsModel : PageModel
    {
        public PostViewModel Post { get; set; }

        public IPostApplication _PostApplication { get; set; }
        public BLogDetailsModel(IPostApplication PostApplication)
        {
            _PostApplication = PostApplication;
        }
        public void OnGet(int id)
        {
            Post = _PostApplication.GetById(id);
        }
    }
}
