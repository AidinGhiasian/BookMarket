using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Domain.Account.AD
{
    public interface IAccountRepository
    {
       public void Craete(Account account);
        public Account? Getby(int id);
        public void Updateby(Account account);
        public List<Account> GetAccounts();
        public Account Getby(string phone);


    }
}
