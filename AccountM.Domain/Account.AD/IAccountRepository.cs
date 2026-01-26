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
        Task Updateby(Account account);
        public List<Account> GetAccounts(string? name,string? phone);
        public Account Getby(string phonenumber);
        public void Delete(int id);
        public Account? GetbyId(string phone);

    }
}
