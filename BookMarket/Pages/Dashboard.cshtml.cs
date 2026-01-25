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
        private readonly IAccountApplication _ccountApplication;

        public DashboardModel(IAccountApplication ccountApplication)
        {
            _ccountApplication = ccountApplication;
        }

        public void OnGet(string id)
        {

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


            _ccountApplication.Create(account);
            TempData["success"] = "کتابخوان جدید ثبت شد...";
        }
    }
}
