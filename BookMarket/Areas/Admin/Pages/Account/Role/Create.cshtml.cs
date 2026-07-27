using AccountM.Application.Contracts.RoleApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Account.Role
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IRoleApplication _roleApplication;
        public CreateModel(IRoleApplication roleRepository)
        {
            _roleApplication = roleRepository;
        }

        public void OnGet() { }

        public IActionResult OnPost(CreateViewModel command)
        {
            if (!ModelState.IsValid) return Page();
            try
            {
                _roleApplication.Create(command);
                TempData["success"] = "نقش ایجاد شد.";
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Page();
            }
        }
    }
}
