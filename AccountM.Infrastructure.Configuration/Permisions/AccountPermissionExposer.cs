using AccountMInfrastructureConfiguration.Permisions;
using BlogMInfrastructureConfiguration.Permissions;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccountManagementConfiguration.Permission
{
    public class AccountPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {
            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                    "حساب های کاربری",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermision.ListAccount,"لیست  حساب های کاربری"),
                        new PermissionDTO(AccountPermision.CreateAccount,"افزودن  حساب کاربری"),
                        new PermissionDTO(AccountPermision.EditAccount,"ویرایش  حساب های کاربری"),
                        new PermissionDTO(AccountPermision.SearchAccount,"جستجو  حساب های کاربری"),
                    }

                },
                {
                    "نقش ها",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermision.ListRoles,"لیست نقش ها"),
                        new PermissionDTO(AccountPermision.CreateRoles," افزودن نقش ها"),
                        new PermissionDTO(AccountPermision.EditRoles,"ویرایش نقش ها"),
                    }
                }
            };
        }
    }
}
