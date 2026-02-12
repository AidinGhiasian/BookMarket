using AccountM.Application.Contacts.AccountApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
