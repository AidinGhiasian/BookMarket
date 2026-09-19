using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManegment.Configuration.Permissions
{
    public static class DiscountPermissions
    {
        //CustomerDiscount
        public const int ListCustomerDiscount = 30;
        public const int CreateCustomerDiscount = 31;
        public const int EditCustomerDiscount = 32;
        public const int SearchCustomerDiscount = 33;
        //ColleagueDiscount
        public const int ListColleagueDiscount = 34;
        public const int CreateColleagueDiscount = 35;
        public const int EditColleagueDiscount = 36;
        public const int SearchColleagueDiscount = 37;
    }
}
