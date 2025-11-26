using AM.Domain.Account.AD;

namespace AM.Infrastructure.EFCore.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountDbContext _dbContext;
        public AccountRepository(AccountDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Craete(Account account)
        {
            var acc = new Account(account.Name, account.Family,
                account.PhoneNumber, account.Email,
                account.BirthDate, account.Addres,
                account.Password,account.RePassword);

            _dbContext.Accounts.Add(acc);
            _dbContext.SaveChanges();
        }


        public List<Account> GetAccounts()
        {
            return _dbContext.Accounts.ToList();
        }
        public Account? Getby(int id)
        {
            var account = _dbContext.Accounts.FirstOrDefault(a => a.Id == id);
            if (account != null) return account;
            return null;
        }

        public Account Getby(string phone)
        {
            var acc = _dbContext.Accounts.FirstOrDefault(x => x.PhoneNumber == phone);
            if (acc != null) return acc;
            return null;
        }

        public void Updateby(Account account)
        {
            var acc = _dbContext.Accounts.FirstOrDefault(x => x.Id == account.Id);
            if (acc != null)
            {

                acc.Edit(account.Name, account.Family, account.PhoneNumber, account.Email, account.BirthDate, account.Addres,account.Password,account.RePassword);

                _dbContext.Accounts.Update(acc);
                _dbContext.SaveChanges();
            }
        }
    }
}
