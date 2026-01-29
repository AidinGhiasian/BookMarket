using AccountM.Application.Contacts.AccountApplication;
using AccountM.Infrastructure.EFCore;
using AccountM.Infrastructure.EFCore.Migrations;
using AM.Domain.Account.AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages
{
    public class DashboardModel : PageModel
    {

        public List<AccountViewModel> Accounts { get; set; }
     

        private readonly IAccountApplication _accountApplication;

        public DashboardModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet(string? Name,string? PhoneNumber)
        {
                Accounts = _accountApplication.GetAccounts(Name, PhoneNumber);
        }

        public void OnPost(CreateViewModel command)
        {
            var account = new CreateViewModel
            {
                Name = command.Name,
                Family = command.Family,
                Addres = command.Addres,
                BirthDate = command.BirthDate,
                Email = command.Email,
                Password = command.Password,
                RePassword = command.RePassword,
                PhoneNumber = command.PhoneNumber

            };


            _accountApplication.Create(account);
            TempData["success"] = "کتابخوان جدید ثبت شد...";
        }
    }
}
