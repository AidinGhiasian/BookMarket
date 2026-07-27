using AccountM.Application.Contracts.RoleApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Account.Role
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        public EditViewModel Command { get; set; } = new();
        public List<SelectListItem> Permissions { get; set; } = new();

        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }

        public void OnGet(int id)
        {
            Command = _roleApplication.GetDetails(id);
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key, value) in exposedPermissions)
                {
                    var group = new SelectListGroup { Name = key };
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };
                        if (Command.MappedPermissions != null &&
                            Command.MappedPermissions.Any(x => x.Code == permission.Code))
                            item.Selected = true;
                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(EditViewModel command)
        {
            if (!ModelState.IsValid)
            {
                Command = command;
                OnGet(command.Id);
                return Page();
            }
            _roleApplication.Edit(command);
            TempData["success"] = "نقش ویرایش شد.";
            return RedirectToPage("Index");
        }
    }
}
