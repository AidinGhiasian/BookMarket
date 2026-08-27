using AccountM.Application.Contracts.AccountApplication;
using AccountMInfrastructureConfiguration.Permisions;
using BlogMInfrastructureConfiguration.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application.Categoreis;
using Services.Infrastructure;
using System.IO.IsolatedStorage;
using System.Net.NetworkInformation;

namespace BookMarket.Areas.Admin.Account
{
    //[Authorize(Roles = Roles.Admin + "," + Roles.Guest)]
    public class IndexModel : PageModel
    {
        private readonly IAccountApplication _accountApplication;
        public IndexModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public List<AccountViewModel> Accounts { get; set; }


        [NeedsPermission(AccountPermission.DeleteAccount)]
        public IActionResult OnGetDelete(int id)
        {
            _accountApplication.Delete(id);
            TempData["Avalable"] = "کتابخوان غیر فعال شد...";

            return Redirect("./AdminIndex");
        }
        [NeedsPermission(AccountPermission.RestoreAccount)]
        public IActionResult OnGetRestore(int id)
        {
            _accountApplication.Restore(id);
            TempData["NotAvalable"] = "کتابخوان فعال شد...";

            return Redirect("./AdminIndex");
        }



        [NeedsPermission(AccountPermission.ListAccount)]
        public void OnGet(bool IsStatus = true)
        {
            if (IsStatus == true)
            {
                Accounts = _accountApplication.GetAccounts(true);
            } else if (IsStatus == false)
            {
                Accounts = _accountApplication.GetAccounts(false);
            }
        }
        [NeedsPermission(AccountPermission.CreateAccount)]
        public void OnPostCreateAccount(AccountViewModel account)
        {
            var createAccount = new AccountViewModel
            {
                Name = account.Name,
                Family = account.Family,
                Address = account.Address,
                BirthDate = account.BirthDate,
                Email = account.Email,
                Password = account.Password,
                PhoneNumber = account.PhoneNumber,
            };
        }
        [NeedsPermission(AccountPermission.EditRoles)]//تغییر نقش یک فرد یا تغییر نقش در اینجا امکان این که از اتربیوت ادیت اکانت هم میتوان استفاده کرد
        public void OnGetChangeRole(int id, int roleId)
        {
            _accountApplication.ChangeRole(id, roleId); 
        }
}

}
