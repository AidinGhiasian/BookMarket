using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountM.Application.Contacts.AccountApplication;
using AM.Domain.Account.AD;

namespace AccountM.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountApplication;
        public AccountApplication(IAccountRepository accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void Create(CreateViewModel model)
        {
            var acc = new Account(model.Name, model.Family, model.PhoneNumber, model.Email, model.BirthDate, model.Addres,model.Password,model.RePassword);
            _accountApplication.Craete(acc);
        }

        public void Edit(EditViewModel model)
        {
            var acc = _accountApplication.Getby(model.Id);
            acc.Edit(model.Name, model.Family, model.PhoneNumber, model.Email, model.BirthDate, model.Addres,model.Password,model.RePassword);

            _accountApplication.Updateby(acc);
        }


        public List<AccountViewModel> GetAccounts()
        {
            var aa = _accountApplication.GetAccounts();
            var List = new List<AccountViewModel>();
            foreach (var account in aa)
            {
                var a = map(account);

                List.Append(a);
            }
            return List;
        }

        public AccountViewModel GetDetails(int id)
        {
            var accc = _accountApplication.Getby(id);
            return map(accc);
        }
        private AccountViewModel map(Account model)
        {
            var a = new AccountViewModel()
            {
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                Addres = model.Addres
            };
            return a;

        }
    }
}
