
using AccountM.Application.Contracts.AccountApplication;
using AccountM.Application.Contracts.RoleApplication;
using AccountMInfrastructureConfiguration.Permisions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace ServiceHost.Areas.Admin.Pages.Account.Role
{
    public class CreateModel : PageModel
    {
       
        private readonly IRoleApplication _roleRepository;

        public CreateModel(IRoleApplication roleRepository)
        {
           _roleRepository = roleRepository;
        }
        [NeedsPermission(AccountPermission.CreateRoles)]
        public void OnGet()
        {
        }
        
        public IActionResult OnPost(AccountM.Application.Contracts.RoleApplication.CreateViewModel command)
        {
           
            var result = _roleRepository.Create(command);
            return RedirectToPage("Index");
        }
    }
}