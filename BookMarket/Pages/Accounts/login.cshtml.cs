using AccountM.Infrastructure.EFCore;
using AccountM.Infrastructure.EFCore.Migrations;
using AM.Domain.Account.AD;
using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountM.Application;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Pages.Account
{

    public class loginModel : PageModel
    {
        public List<AccountViewModel> Accounts { get; set; }
        public AccountViewModel Account { get; set; }


        private readonly IAccountApplication _accountapplication;
        public loginModel(IAccountApplication accountApplication)
        {
            _accountapplication = accountApplication;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostLogin(string? email, string? password)
        
        {
            var Exist = _accountapplication.login(email, password);

            if (Exist == true) ;
            {
                return RedirectToPage("/dashboard");
            }


        }


    }
}
