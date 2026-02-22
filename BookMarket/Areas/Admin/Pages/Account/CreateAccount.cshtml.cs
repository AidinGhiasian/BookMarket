using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Account
{
    public class CreateAccountModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public CreateAccountModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(CreateViewModel added)
        {
            
            _accountApplication.Create(added);
            TempData["success"] = "کتابخوان جدید ثبت شد...";
           return Redirect("./AdminIndex");
        }
    }
}
