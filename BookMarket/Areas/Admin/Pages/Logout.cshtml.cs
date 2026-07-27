using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application.AuthHelper;

namespace BookMarket.Areas.Admin.Pages
{
    [Authorize]
    public class LogoutModel : PageModel
    {
        private readonly IAuthHelper _authHelper;
        public LogoutModel(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }
        public void OnGet() { }

        public async Task<IActionResult> OnPost()
        {
            await _authHelper.SignOutAsync();
            return Redirect("~/");
        }
    }
}
