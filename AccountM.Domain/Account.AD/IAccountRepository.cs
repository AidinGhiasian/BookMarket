using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Application;

namespace AM.Domain.Account.AD
{
    public interface IAccountRepository: IRepositoryBase<Account>
    {
        public void Create(Account account);
        public Account? GetbyId(int id);
        public List<Account> GetAccounts(bool isStatus);
        public Account Getby(string phonenumber);
        public void Delete(int id);
        public void Restore(int id);
        public OperationResult ChangePassword(string password);

    }
}
