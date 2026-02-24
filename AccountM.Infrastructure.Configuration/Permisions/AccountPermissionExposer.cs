using AccountMInfrastructureConfiguration.Permisions;
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
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "حسابهای کاربری",new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermisions.ListAccount,"لیست  حسابهای کاربری"),
                        new PermissionDto(AccountPermisions.CreateAccount,"افزودن  حسابهای کاربری"),
                        new PermissionDto(AccountPermisions.EditAccount,"ویرایش  حسابهای کاربری"),
                        new PermissionDto(AccountPermisions.SearchAccount,"جستجو  حسابهای کاربری"),
                    }

                },
                {
                    "نقش ها",new List<PermissionDto>
                    {
                        new PermissionDto(AccountPermisions.ListRoles,"لیست نقش ها"),
                        new PermissionDto(AccountPermisions.CreateRoles," افزودن نقش ها"),
                        new PermissionDto(AccountPermisions.EditRoles,"ویرایش نقش ها"),
                    }
                }
            };
        }
    }
}
