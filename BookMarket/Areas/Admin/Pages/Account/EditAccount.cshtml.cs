using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Account
{
    [Authorize(Roles = "Admin")]
    public class EditAccountModel : PageModel
    {
        private readonly IAccountApplication _accountapplication;
        public EditAccountModel(IAccountApplication accountapplication)
        {
            _accountapplication = accountapplication;
        }
        public EditViewModel? account { get; set; }

        public void OnGet(int id)
        {
            account = _accountapplication.Getdetail(id);
        }

        public IActionResult OnPost(EditViewModel command)
        {
            if (!ModelState.IsValid)
            {
                account = command;
                return Page();
            }
            _accountapplication.Edit(command);
            TempData["success"] = "ویرایش با موفقیت انجام شد.";
            return RedirectToPage("/Admin/Account/AdminIndex");
        }
    }
}
