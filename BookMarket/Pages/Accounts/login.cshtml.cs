using AccountM.Infrastructure.EFCore;
using AM.Domain.Account.AD;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AccountM.Application;
using Microsoft.AspNetCore.Mvc;
using BookM.ClientQueries.Model.Account;
using AccountM.Application.Contracts.AccountApplication;
using Services.Application;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult OnGet()
        {
            if (User.Identity?.IsAuthenticated==true)
            {
                return Forbid();
            }
            return Page();
        }

        public IActionResult OnPostLogin(string? phone, string? password)
        {
            OperationResult operationResult = new OperationResult();
            var result = _accountQueries.Login(phone, password);

            if (result.Failure)
            {
                TempData["LoginError"] = ApplicationMessage.NotFound;
                return Page();
            }
         
           
            TempData["SwalMessage"] =" ورود با موفقیت انجام شد";
            TempData["SwalType"] = "success"; // نوع پیام: success, error, warning, info
            TempData.Keep("SwalMessage");

            return RedirectToPage("/Index");

        }
        public IActionResult OnPostRegister(CreateViewModel model)
        {
            model.BirthDate = DateTime.Now;
            model.Address = " ";
            model.Email=" ";
            
            _accountQueries.Register(model);
            return RedirectToPage("/index");
        }




    }
}
