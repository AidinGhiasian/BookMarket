using Services.Application;

namespace BookM.ClientQueries.Model.Account
{
    public interface IAccountQueries
    {
        AccountViewModel? Account(int id);
        AccountViewModel? Account(string phoneNumber);
        EditViewModel? GetDetail(int id);
        EditViewModel? GetDetail(string phone);
        Task<OperationResult> Login(string? phone, string? password);
        Task<OperationResult> Register(AccountM.Application.Contracts.AccountApplication.CreateViewModel model);
    }
}
