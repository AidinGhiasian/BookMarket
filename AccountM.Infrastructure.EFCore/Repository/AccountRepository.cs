using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Domain.Account.AD;
using Services;

namespace AccountM.Infrastructure.EFCore.Repository
{
    public class AccountRepository :RepositoryBase<Account>, IAccountRepository
    {
        private readonly AccountDbContext _accountdbcontext;
        public AccountRepository(AccountDbContext accountdbcontext):base(accountdbcontext) 
        {
            _accountdbcontext = accountdbcontext;
        }
        public void Craete(Account account)
        {
            _accountdbcontext.Account.Add(account);
            _accountdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var DA =_accountdbcontext.Account.Find(id);
            if (DA != null)
            {
                _accountdbcontext.Account.Remove(DA);
            }
        }

        public List<Account> GetAccounts(string name)
        {
            return _accountdbcontext.Account.Where(x => x.Name == name).ToList();
 
        } 

        public Account? GetbyId(int id)
        {
          return  _accountdbcontext.Account.FirstOrDefault(x=>x.Id == id);     
        }

        public Account Getby(string phonenumber)
        {
          return  _accountdbcontext.Account.FirstOrDefault(x => x.PhoneNumber == phonenumber);
        }

        public async Task Updateby(Account account)
        {
            var EA=_accountdbcontext.Account.FirstOrDefault(x=>x.Id == account.Id);
            if(EA != null)
            {
                EA.Edit(account.Name, account.Family, account.PhoneNumber
                    , account.Email, account.BirthDate, account.Addres
                    , account.Password, account.RePassword);
                await _accountdbcontext.SaveChangesAsync();
            }
        }


    }
}
