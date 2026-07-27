using AM.Domain.Account.AD;
using Microsoft.EntityFrameworkCore;
using Services.Application;

namespace AccountM.Infrastructure.EFCore.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly AccountDbContext _accountdbcontext;

        public AccountRepository(AccountDbContext accountdbcontext) : base(accountdbcontext)
        {
            _accountdbcontext = accountdbcontext;
        }

        public void Create(Account account)
        {
            _accountdbcontext.Account.Add(account);
            _accountdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var DA = _accountdbcontext.Account.FirstOrDefault(x => x.Id == id);
            if (DA == null) return;
            DA.ChangeStatus(false);
            _accountdbcontext.SaveChanges();
        }

        public void Restore(int id)
        {
            var DA = _accountdbcontext.Account.FirstOrDefault(x => x.Id == id);
            if (DA == null) return;
            DA.ChangeStatus(true);
            _accountdbcontext.SaveChanges();
        }

        public List<Account> GetAccounts(bool isStatus)
            => _accountdbcontext.Account.Where(x => x.IsAvalable == isStatus).ToList();

        public Account? GetbyId(int id)
            => _accountdbcontext.Account.FirstOrDefault(x => x.Id == id);

        public Account? GetbyId(string phone)
            => _accountdbcontext.Account.FirstOrDefault(x => x.PhoneNumber == phone);

        public Account? Getby(string phonenumber)
            => _accountdbcontext.Account.FirstOrDefault(x => x.PhoneNumber == phonenumber);

        public new List<Account> GetAll() => _accountdbcontext.Account.ToList();
    }
}
