using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Account
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public IndexModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public List<AccountViewModel> Accounts { get; set; } = new();

        public IActionResult OnPostDelete(int id)
        {
            _accountApplication.Delete(id);
            TempData["Avalable"] = "کتابخوان غیر فعال شد...";
            return RedirectToPage();
        }

        public IActionResult OnPostRestore(int id)
        {
            _accountApplication.Restore(id);
            TempData["NotAvalable"] = "کتابخوان فعال شد...";
            return RedirectToPage();
        }

        public void OnGet(bool IsStatus = true)
        {
            Accounts = _accountApplication.GetAccounts(IsStatus);
        }
    }
}
