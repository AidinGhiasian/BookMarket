using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountM.Application.Contracts.AccountApplication;

namespace BookMarket.Pages.Account
{
    [AllowAnonymous]
    public class loginModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;

        public loginModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        [BindProperty] public string? LoginPhone { get; set; }
        [BindProperty] public string? LoginPassword { get; set; }

        public void OnGet() { }

        public async Task<IActionResult> OnPostLoginAsync(string? phone, string? password)
        {
            var result = await _accountApplication.LoginAsync(phone, password);
            if (!result.Success)
            {
                TempData["Error"] = result.Message;
                return Page();
            }
            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostRegisterAsync(CreateViewModel model)
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                _accountApplication.Create(model);
                TempData["Success"] = "ثبت‌نام با موفقیت انجام شد، اکنون وارد شوید.";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Page();
            }
        }
    }
}
