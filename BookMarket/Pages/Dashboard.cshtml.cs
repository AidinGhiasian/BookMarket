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

        public AccountViewModel Account { get; set; }

        private readonly IAccountApplication _accountApplication;

        public DashboardModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet(bool isStatus = true)
        {
            if (isStatus)
            {
                Accounts = _accountApplication.GetAccounts(true);

            }
            else if (isStatus == false)
            {
                Accounts = _accountApplication.GetAccounts(false);

            }


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
                PhoneNumber = command.PhoneNumber

            };


            _accountApplication.Create(account);
            TempData["success"] = "کتابخوان جدید ثبت شد...";
        }
        public void OnGetAccountInformation(int id)
        {
            Account = _accountApplication.GetBy(id);
        }
        public IActionResult OnGetDelete(int id)
        {
            _accountApplication.Delete(id);
            TempData["Avalable"] = "کتابخوان غیر فعال شد...";
            return
            RedirectToPage("/Dashboard");

        }
        public IActionResult OnGetRestore(int id)
        {
            _accountApplication.Restore(id);
            TempData["NotAvalable"] = "کتابخوان فعال شد...";
            return
            RedirectToPage("/Dashboard");

        }

    }
}
