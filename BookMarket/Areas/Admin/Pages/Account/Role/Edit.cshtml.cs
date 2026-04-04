using AccountM.Application.Contracts.RoleApplication;
using AccountMInfrastructureConfiguration.Permisions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Infrastructure;

namespace ServiceHost.Areas.Admin.Pages.Account.Role
{
    public class EditModel : PageModel
    {
        public EditViewModel Command;
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        private readonly IRoleApplication _roleApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;

        public EditModel(IRoleApplication roleApplication, IEnumerable<IPermissionExposer> exposers)
        {
            _roleApplication = roleApplication;
            _exposers = exposers;
        }
        //[NeedsPermission(AccountPermisions.EditRoles)]

        public void OnGet(int id)
        {
            Command = _roleApplication.GetDetails(id);
            foreach (var exposer in _exposers)
            {
                var exposedPermissions = exposer.Expose();
                foreach (var (key, value) in exposedPermissions)
                {
                    var group = new SelectListGroup {Name = key};
                    foreach (var permission in value)
                    {
                        var item = new SelectListItem(permission.Name, permission.Code.ToString())
                        {
                            Group = group
                        };

                        if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                            item.Selected = true;

                        Permissions.Add(item);
                    }
                }
            }
        }

        public IActionResult OnPost(EditViewModel command)
        {
            var result = _roleApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}