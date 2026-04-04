
using AccountM.Application.Contracts.RoleApplication;
using AccountManagement.Domain.RoleAgg;
using AccountMInfrastructureConfiguration.Permisions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Infrastructure;
using System.Collections.Generic;


namespace BookMarket.Areas.Admin.Pages.Account.Role
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<RoleViewModel> Roles;

        private readonly IRoleApplication _roleRepository;

        public IndexModel(IRoleApplication roleRepository)
        {
            _roleRepository = roleRepository;
        }
        //[NeedsPermission(AccountPermisions.ListRoles)]

        public void OnGet()
        {
            Roles = _roleRepository.List();
        }
    }
}
