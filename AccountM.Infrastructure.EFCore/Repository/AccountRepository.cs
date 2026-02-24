using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using AccountM.Infrastructure.EFCore.Migrations;
using AM.Domain.Account.AD;
using FLEXYGO.PushService;
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
        public void Craete(Account account)
        {
            _accountdbcontext.Account.Add(account);
            _accountdbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var DA = _accountdbcontext.Account.First(x => x.Id == id);
            if (DA != null)
            {
                DA.ChangeStatus(false);
                _accountdbcontext.SaveChanges();
            }
        }
        public void Restore(int id)
        {
            var DA = _accountdbcontext.Account.First(x => x.Id == id);
            if (DA != null)
            {
                DA.ChangeStatus(true);
                _accountdbcontext.SaveChanges();
            }
        }

        public List<Account> GetAccounts(bool isStatus)
        {


            var accounts = _accountdbcontext.Account.Where(x=>x.IsAvalable==isStatus).ToList();
            
            return accounts;
        }

        public Account? GetbyId(int id)
        {
            return _accountdbcontext.Account.FirstOrDefault(x => x.Id == id);
        }
        public Account? GetbyId(string phone)
        {
            return _accountdbcontext.Account.FirstOrDefault(x => x.PhoneNumber == phone);
        }

        public Account Getby(string phonenumber)
        {
            return _accountdbcontext.Account.FirstOrDefault(x => x.PhoneNumber == phonenumber);
        }
       

        public OperationResult login(string? phonNumber, string? password)
        {
            OperationResult result = new OperationResult();
            var account = _accountdbcontext.Account.FirstOrDefault(x => x.PhoneNumber == phonNumber);
            if (account != null)
            {
                if (account.Password == password)
                {
                    return result.IsSuccess();
                }
                else
                {
                    return result.Failed(ApplicationMessage.NotFund);
                }
            }
            return result.Failed(ApplicationMessage.NotFund);

        }
    }
}
