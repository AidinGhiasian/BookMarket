namespace Services.Application.AuthHelper
{
    public interface IAuthHelper
    {
        AuthViewModel CurrentAccountInfo();
        List<int> GetPermissions();
        int CurrentAccountId();
        string? CurrentAccountMobile();
        string? CurrentAccountRole();
        bool IsAuthenticated();
        Task SigninAsync(AuthViewModel account);
        Task SignOutAsync();
    }
}
