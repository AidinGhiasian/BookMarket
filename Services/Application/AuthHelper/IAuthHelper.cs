using System.Collections.Generic;

namespace Services.Application.AuthHelper
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthViewModel account);
        string CurrentAccountRole();
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
        int CurrentAccountId();
        string CurrentAccountMobile();
    }
}
