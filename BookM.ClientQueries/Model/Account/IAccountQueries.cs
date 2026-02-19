using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Model.Account
{
    public interface IAccountQueries
    {
        public AccountViewModel Account(int id);
        public AccountViewModel Account(string phoneNumber);
        public EditViewModel GetDetail(int id);
    }
}
