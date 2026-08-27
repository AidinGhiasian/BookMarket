using AccountM.Application.Contracts.AccountApplication;
using AccountMInfrastructureConfiguration.Permisions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Account
{
    public class EditAccountModel : PageModel
    {
        private readonly IAccountApplication _accountapplication;
        public EditAccountModel(IAccountApplication accountapplication)
        {
            _accountapplication = accountapplication;
        }
        public EditViewModel account {  get; set; }

        [NeedsPermission(AccountPermission.EditAccount)]
        public void OnGet(int id)
        {
            account = _accountapplication.Getdetail(id);
        }
        public IActionResult OnPost(EditViewModel command) 
        {
          _accountapplication.Edit(command);
            return Redirect("/Admin/Account/AdminIndex");

        }
    }
}
