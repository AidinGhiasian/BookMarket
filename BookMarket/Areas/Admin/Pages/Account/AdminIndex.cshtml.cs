using System.IO.IsolatedStorage;
using System.Net.NetworkInformation;
using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Account
{
    public class IndexModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public IndexModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public List<AccountViewModel> Accounts { get; set; }

        public IActionResult OnGetDelete(int id)
        {
            _accountApplication.Delete(id);
            TempData["Avalable"] = "کتابخوان غیر فعال شد...";
           
            return Redirect("./AdminIndex");
        }
        public IActionResult OnGetRestore(int id)
        {
            _accountApplication.Restore(id);
            TempData["NotAvalable"] = "کتابخوان فعال شد...";

            return Redirect("./AdminIndex");
        }
        public void OnGet(bool IsStatus = true)
        {
            if(IsStatus == true)
            {
                Accounts = _accountApplication.GetAccounts(true);
            }else if (IsStatus == false)
            {
                Accounts = _accountApplication.GetAccounts(false);
            }
        }
        public void OnPostCreateAccount(AccountViewModel account)
        {
            var createAccount = new AccountViewModel
            {
                Name = account.Name,
                Family = account.Family,
                Addres = account.Addres,
                BirthDate = account.BirthDate,
                Email = account.Email,
                Password = account.Password,
                PhoneNumber = account.PhoneNumber,
            };
        }
    }

}
