
using AccountMInfrastructureConfiguration.Permisions;
using BookM.ClientQueries;
using BookM.ClientQueries.Model.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Application.AuthHelper;
using Services.Application.Categoreis;
using Services.Infrastructure;

namespace BookMarket.Pages
{
    //[Authorize(Roles = Roles.User)] // کاربر باید دسترسی ورود به این صفحه را داشته  باشد و این به کاستوم کردن هر نقش کمک میکند
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


        [NeedsPermission(AccountPermission.UserDashboard)]
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
