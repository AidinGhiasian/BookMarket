using System;
using System.Collections.Generic;
using AccountM.Application.Contacts.AccountApplication;
using AM.Domain.Account.AD;

namespace AccountM.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;

        public AccountApplication(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public void Create(CreateViewModel model)
        {
            var acc = new Account(
                model.Name,
                model.Family,
                model.PhoneNumber,
                model.Email,
                model.BirthDate,
                model.Addres,
                model.Password
            );

            _accountRepository.Craete(acc);
        }

        public void Delete(int id)
        {
            _accountRepository.Delete(id);
        }

        public void Edit(EditViewModel model)
        {
            var acc = _accountRepository.Getby(model.Name); 
            acc.Edit(
                model.Name,
                model.Family,
                model.PhoneNumber,
                model.Email,
                model.BirthDate,
                model.Addres,
                model.Password
            );

            _accountRepository.Updateby(acc);
        }

        public List<AccountViewModel> GetAccounts(string? name,string? phone)
        {
            var accounts = _accountRepository.GetAccounts(name,phone); 
            var list = new List<AccountViewModel>();

            foreach (var account in accounts)
            {
                list.Add(Map(account)); 
            }

            return list;
        }

        public AccountViewModel Getby(int id)
        {
            var account = _accountRepository.Getby(id.ToString());
            return Map(account);
        }

        public AccountViewModel GetBy(int id)
        {
           var a=  _accountRepository.GetbyId(id);
            return Map(a);
        }
        public AccountViewModel GetBy(string phone)
        {
            var a = _accountRepository.Getby(phone);
            return Map(a);
            
        }

        public bool login(string? email, string? password)
        {
            return _accountRepository.login(email, password);
        }

        private AccountViewModel Map(Account model)
        {
            return new AccountViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                cratetiondate = model.CreationDate, 
                Addres = model.Addres,
                Password = model.Password,
            };
        }
    }
}
