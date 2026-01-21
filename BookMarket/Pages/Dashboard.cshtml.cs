using AccountM.Application.Contacts.AccountApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly IAccountApplication accountApplication;
        public DashboardModel(IAccountApplication _accountApplication)
        {
            _accountApplication = accountApplication;
        }
        public void OnGet(string id)
        {

        }
    }
}
