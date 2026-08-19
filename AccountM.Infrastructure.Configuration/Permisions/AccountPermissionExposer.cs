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
                        new PermissionDTO(AccountPermisions.ListAccount,"لیست  حسابهای کاربری"),
                        new PermissionDTO(AccountPermisions.CreateAccount,"افزودن  حسابهای کاربری"),
                        new PermissionDTO(AccountPermisions.EditAccount,"ویرایش  حسابهای کاربری"),
                        new PermissionDTO(AccountPermisions.SearchAccount,"جستجو  حسابهای کاربری"),
                    }

                },
                {
                    "نقش ها",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermisions.ListRoles,"لیست نقش ها"),
                        new PermissionDTO(AccountPermisions.CreateRoles," افزودن نقش ها"),
                        new PermissionDTO(AccountPermisions.EditRoles,"ویرایش نقش ها"),
                    }
                }
            };
        }
    }
}
