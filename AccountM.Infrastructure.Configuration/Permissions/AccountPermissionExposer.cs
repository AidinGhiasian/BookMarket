using AccountMInfrastructureConfiguration.Permisions;
using Services.Infrastructure;


namespace AccountManagementConfiguration.Permission
{
    public class AccountPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {
            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                     "مدیریت",new List<PermissionDTO>
                    {
                          new PermissionDTO(AccountPermission.ListAccount,"دسترسی مدیریتی"),
                          new PermissionDTO(AccountPermission.UserDashboard,"دسترسی کاربری"),
                    }
                },
                {
                    "حساب های کاربری",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermission.ListAccount,"لیست  حساب های کاربری"),
                        new PermissionDTO(AccountPermission.CreateAccount,"افزودن  حساب کاربری"),
                        new PermissionDTO(AccountPermission.EditAccount,"ویرایش  حساب های کاربری"),
                        new PermissionDTO(AccountPermission.SearchAccount,"جستجو  حساب های کاربری"),
                        new PermissionDTO(AccountPermission.Activating,"حذف و بازگردانی حساب های کاربری"),
                    }

                },
                {
                    "نقش ها",new List<PermissionDTO>
                    {
                        new PermissionDTO(AccountPermission.ListRoles,"لیست نقش ها"),
                        new PermissionDTO(AccountPermission.CreateRoles," افزودن نقش ها"),
                        new PermissionDTO(AccountPermission.EditRoles,"ویرایش نقش ها"),
                    }
                }
            };
        }
    }
}
