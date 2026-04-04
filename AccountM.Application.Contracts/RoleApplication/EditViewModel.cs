using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountM.Application.Contracts.RoleApplication
{
    public class EditViewModel:CreateViewModel
    {
        public int Id { get; set; }
        public bool isActive { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }
        public EditViewModel()
        {
            Permissions = new List<int>();
        }
    }
}
