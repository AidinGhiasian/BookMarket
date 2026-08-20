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
                    "حسابهای کاربری",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermision.ListAccount,"لیست  حسابهای کاربری"),
                        new PermissionDTO(AccountPermision.CreateAccount,"افزودن  حسابهای کاربری"),
                        new PermissionDTO(AccountPermision.EditAccount,"ویرایش  حسابهای کاربری"),
                        new PermissionDTO(AccountPermision.SearchAccount,"جستجو  حسابهای کاربری"),
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
