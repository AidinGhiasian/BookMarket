using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application.AuthHelper;

namespace BookMarket.Areas.Admin.Pages.Account
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;
        public ChangePasswordModel(IAccountApplication accountApplication,IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }
        public PasswordViewModel Password { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(string password, string rePassword)
        {
            var newPasssword = new PasswordViewModel
            {
                Id = _authHelper.CurrentAccountId(),
                Password = password,
                RePassword = rePassword
            };
            _accountApplication.ChangePassword(newPasssword);
            return RedirectToPage("Admin/Account/AdminIndex");
        }
    }
}
