using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMInfrastructureConfiguration.Permisions
{
    public static class AccountPermission
    {


        //Account
        public const int ListAccount =100;
        public const int SearchAccount = 101;
        public const int CreateAccount = 102;
        public const int EditAccount = 103;
        public const int DeleteAccount = 104;
        public const int RestoreAccount = 105;
        //Roles
        public const int ListRoles = 106;
        public const int CreateRoles = 107;
        public const int EditRoles = 108;

        //

        public const int AdminDashboard = 109;
        public const int UserDhaboard = 110;

    }
}
