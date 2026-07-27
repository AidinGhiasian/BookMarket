using Services.Application;

namespace AccountM.Application.Contracts.AccountApplication
{
    public interface IAccountApplication
    {
        void Create(CreateViewModel model);
        void Edit(EditViewModel model);
        AccountViewModel? GetBy(int id);
        List<AccountViewModel> GetAccounts(bool isStatus);
        void Delete(int id);
        void Restore(int id);
        AccountViewModel? GetBy(string phone);
        Task<OperationResult> LoginAsync(string? phone, string? password);
        List<AccountViewModel> GetAll();
        EditViewModel Getdetail(int id);
        AccountViewModel? GetdetailInfo(int id);
        Task LogoutAsync();
        OperationResult ChangePassword(PasswordViewModel command);
    }
}
