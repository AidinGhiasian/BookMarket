using BlogM.Application.Contracts.BlogCategoryApplication;
using BlogM.Application.Contracts.PostApplication;
using BlogMInfrastructureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Blog
{
    public class EditBlogModel : PageModel
    {
        private readonly IPostApplication _postApplication;
        private readonly IBlogCategoryApplication _blogCategoryApplication;
        public EditBlogModel(IPostApplication postApplication, IBlogCategoryApplication blogCategoryApplication)
        {
            _postApplication = postApplication;
            _blogCategoryApplication = blogCategoryApplication;
        }
        public EditViewModel Blog { get; set; }
        public List<BlogCategoryViewModel> BlogCategories { get; set; }

        [NeedsPermission(BlogPermission.EditPost)]
        public void OnGet(int id)
        {
            Blog = _postApplication.GetDetailes(id);
            BlogCategories = _blogCategoryApplication.GetAll();
        }
        public IActionResult OnPost(EditViewModel command)
        {
          _postApplication.Update(command);

            return Redirect("./adminIndex");

        }
    }
}
