using Services.Application;

namespace AM.Domain.Account.AD
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        void Create(Account account);
        Account? GetbyId(int id);
        Account? GetbyId(string phone);
        List<Account> GetAccounts(bool isStatus);
        Account? Getby(string phonenumber);
        void Delete(int id);
        void Restore(int id);
        new List<Account> GetAll();
    }
}
