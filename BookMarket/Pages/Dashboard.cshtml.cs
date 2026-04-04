
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
        public List<AccountViewModel> Accounts { get; set; }

        public AccountViewModel Account { get; set; }

        public DashboardModel(IAccountQueries accountQueries, IAuthHelper authHelper)
        {
            _accountQueries = accountQueries;
            _authHelper = authHelper;
        }

        public void OnGet(int id)
        {
            Account = _accountQueries.Account(id);
        }
        public IActionResult OnPostLogOut()
        {
           _authHelper.SignOut();
            return RedirectToPage("/Index");
        }
    }
}
