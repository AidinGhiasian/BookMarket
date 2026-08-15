using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using Services.Application;

namespace BookMarket.Pages.Accounts
{
    public class EditAccountModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public EditAccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public EditViewModel Account { get; set; }
        public void OnGet(int id)
        {
            Account = _accountApplication.Getdetail(id);
        }
        public IActionResult OnPost(EditViewModel command)
        {
            OperationResult result = new OperationResult();

            _accountApplication.Edit(command);
            TempData["Success"] = result.Success;
            return RedirectToPage("/Dashboard");

        }
    }
}
