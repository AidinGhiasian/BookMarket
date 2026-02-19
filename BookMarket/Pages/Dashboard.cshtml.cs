
using BookM.ClientQueries;
using BookM.ClientQueries.Model.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IAccountQueries _accountQueries;
        public List<AccountViewModel> Accounts { get; set; }

        public AccountViewModel Account { get; set; }

        public DashboardModel(IAccountQueries accountQueries)
        {
            _accountQueries = accountQueries;
        }

        public void OnGet(int id)
        {
            Account = _accountQueries.Account(id);
        }
    }
}
