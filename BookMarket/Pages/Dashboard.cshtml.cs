
using BookM.ClientQueries;
using BookM.ClientQueries.Model.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application.AuthHelper;

namespace BookMarket.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IAccountQueries _accountQueries;
        private readonly IAuthHelper _authHelper;


        public AccountViewModel Account { get; set; }


        public AuthViewModel CurrentUser { get; set; }



        public DashboardModel(IAccountQueries accountQueries, IAuthHelper authHelper)
        {
            _accountQueries = accountQueries;
            _authHelper = authHelper;
        }



        public void OnGet()
        {

            CurrentUser = _authHelper.CurrentAccountInfo();


            if (CurrentUser.Id > 0)
            {
                Account = _accountQueries.Account((int)CurrentUser.Id);
            }

        }



        public IActionResult OnPostLogout()
        {

            _authHelper.SignOut();

            return RedirectToPage("/Index");

        }

    }
}
