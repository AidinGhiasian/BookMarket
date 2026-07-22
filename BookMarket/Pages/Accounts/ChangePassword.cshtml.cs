using AccountM.Application.Contracts.AccountApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Signers;
using Passbook.Generator;
using Services.Application.AuthHelper;

namespace BookMarket.Pages.Accounts
{
    public class ChangePasswordModel : PageModel
    {
        public void OnGet()
        {

        }
        
        public PasswordViewModel Password { get; set; }

        private readonly IAccountApplication _accountApplicaiton;
        private readonly IAuthHelper _authHelper;

        public ChangePasswordModel(IAccountApplication accountApplication,IAuthHelper authHelper)
        {
            _accountApplicaiton = accountApplication;
            _authHelper = authHelper;
        }
        public void OnPost(string password,string rePassword)
        {
            var newPassword = new PasswordViewModel()
            {
                Id = _authHelper.CurrentAccountId(),
                Password = password,
                RePassword = rePassword,
            };
            _accountApplicaiton.ChangePassword(newPassword);
        }
    }
}
