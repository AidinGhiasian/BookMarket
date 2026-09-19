using Services.Infrastructure;

namespace AccountM.Application.Contracts.RoleApplication
{
    public class EditViewModel:CreateViewModel
    {
        public int Id { get; set; }
        public bool isActive { get; set; }
        public List<PermissionDTO> MappedPermissions { get; set; }
        public EditViewModel()
        {
            Permissions = new List<int>();
        }
    }
}
