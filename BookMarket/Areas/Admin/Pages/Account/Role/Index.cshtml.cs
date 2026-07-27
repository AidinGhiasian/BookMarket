using AccountM.Application.Contracts.RoleApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Account.Role
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        [TempData] public string? Message { get; set; }
        public List<RoleViewModel> Roles { get; set; } = new();

        private readonly IRoleApplication _roleApplication;
        public IndexModel(IRoleApplication roleRepository)
        {
            _roleApplication = roleRepository;
        }

        public void OnGet()
        {
            Roles = _roleApplication.List();
        }
    }
}
