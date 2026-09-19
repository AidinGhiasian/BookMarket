
using Services.Infrastructure;

namespace DiscountManegment.Configuration.Permissions
{
    public class DiscountPermissionsExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDTO>> Expose()
        {
            return new Dictionary<string, List<PermissionDTO>>
            {
                {
                        "CustomerDiscount",new List<PermissionDTO>
                            {
                            new PermissionDTO(DiscountPermissions.ListCustomerDiscount,"نمایش لیست تخفیف مشتریان"),
                            new PermissionDTO(DiscountPermissions.CreateCustomerDiscount,"افزودن تخفیف برای مشتریان"),
                            new PermissionDTO(DiscountPermissions.EditCustomerDiscount,"ویرایش تخفیف برای مشتریان"),
                            new PermissionDTO(DiscountPermissions.SearchCustomerDiscount,"جستجو در تخفیف مشتریان")
                            }

                },
                {
                    "ColleagueDiscount",new List<PermissionDTO>
                    {
                        new PermissionDTO(DiscountPermissions.ListColleagueDiscount,"نمایش لیست تخفیف مشتریان"),
                        new PermissionDTO(DiscountPermissions.SearchColleagueDiscount,"جستجو در لیست تخفیف برای مشتریان"),
                        new PermissionDTO(DiscountPermissions.EditColleagueDiscount,"ویرایش تخفیف برای مشتریان"),
                        new PermissionDTO(DiscountPermissions.CreateColleagueDiscount,"افزودن تخفیف برای مشتریان"),
                    }
                }
            };
        }
    }
}
