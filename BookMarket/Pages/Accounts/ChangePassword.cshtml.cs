using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application.AuthHelper;

namespace BookMarket.Pages.Accounts
{
    [Authorize]
    public class ChangePasswordModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;

        public ChangePasswordModel(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public void OnGet() { }

        public IActionResult OnPost(string password, string rePassword)
        {
            if (string.IsNullOrWhiteSpace(password) || password != rePassword)
            {
                TempData["Error"] = "رمز عبور و تکرار آن یکسان نیست.";
                return Page();
            }

            var newPassword = new PasswordViewModel
            {
                Id = _authHelper.CurrentAccountId(),
                Password = password,
                RePassword = rePassword,
            };
            var res = _accountApplication.ChangePassword(newPassword);
            if (!res.Success)
            {
                TempData["Error"] = res.Message;
                return Page();
            }
            TempData["Success"] = "رمز عبور با موفقیت تغییر یافت.";
            return RedirectToPage("/Dashboard");
        }
    }
}
