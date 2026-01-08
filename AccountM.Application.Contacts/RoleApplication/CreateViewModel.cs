using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using AccountManagement.Domain.RoleAgg;

namespace AccountM.Application.Contacts.RoleApplication
{
    public class CreateViewModel
    {
        public string RoleName { get; set; }
        public List<Permission> Permissions { get; set; }
        public string details { get; set; }
    }
}
