using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace AM.Domain.Account.AD
{
    public interface IAccountRepository: IRepositoryBase<Account>
    {
       public void Craete(Account account);
        public Account? GetbyId(int id);
        public List<Account> GetAccounts(bool isStatus);
        public Account Getby(string phonenumber);
       
        public void Delete(int id);
        public OperationResult login(string? phonNumber, string? password);
        public void Restore(int id);

    }
}
