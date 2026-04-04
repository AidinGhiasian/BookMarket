using AccountM.Infrastructure.EFCore;
using AM.Domain.Account.AD;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountM.Application;
using Microsoft.AspNetCore.Mvc;
using BookM.ClientQueries.Model.Account;
using AccountM.Application.Contracts.AccountApplication;

namespace BookMarket.Pages.Account
{

    public class loginModel : PageModel
    {
        public List<BookM.ClientQueries.Model.Account.AccountViewModel> Accounts { get; set; }
        public BookM.ClientQueries.Model.Account.AccountViewModel Account { get; set; }


        private readonly IAccountQueries _accountQueries;
    
        public loginModel(IAccountQueries accountQueries)
        {
           _accountQueries = accountQueries;
           
        }
        public void OnGet()
        {

        }

        public IActionResult OnPostLogin(string? phone, string? password)
        
        {
            _accountQueries.Login(phone, password);
           
           
            return RedirectToPage("/index");

        }


    }
}
