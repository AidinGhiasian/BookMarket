using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application.AuthHelper;

namespace BookMarket.Areas.Admin.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly IAuthHelper _authHelper;
        public LogoutModel(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }
        public void OnGet()
        {
          
        }
        public IActionResult OnPost()
        {
            _authHelper.SignOut();
            return Redirect("~/index");
        }
    }
}
