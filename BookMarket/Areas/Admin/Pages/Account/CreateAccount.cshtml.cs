using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Account
{
    [Authorize(Roles = "Admin")]
    public class CreateAccountModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public CreateAccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public void OnGet() { }

        public IActionResult OnPost(CreateViewModel added)
        {
            if (!ModelState.IsValid) return Page();
            try
            {
                _accountApplication.Create(added);
                TempData["success"] = "کاربر جدید ثبت شد.";
                return RedirectToPage("/Admin/Account/AdminIndex");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Page();
            }
        }
    }
}
