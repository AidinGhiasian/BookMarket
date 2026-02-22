using System;
using System.Collections.Generic;
using AccountM.Application.Contracts.AccountApplication;
using AM.Domain.Account.AD;
using Services;

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
        public void Restore(int id)
        {
            _accountRepository.Restore(id);
        }
        public void Edit(EditViewModel model)
        {
            var acc = _accountRepository.GetById(model.Id); 
            acc.Edit(
                model.Name,
                model.Family,
                model.PhoneNumber,
                model.Email,
                model.BirthDate,
                model.Addres
               
            );

        
            _accountRepository.SaveChanges();
        }

        public List<AccountViewModel> GetAccounts(bool isStatus)
        {
            return _accountRepository.GetAccounts(isStatus).Select(Map).ToList(); 
           
        }
        public List<AccountViewModel> GetAll()
        {
            var accounts=_accountRepository.GetAll();
            var list = new List<AccountViewModel>();

            foreach (var account in accounts)
            {
                list.Add(Map(account));
            }
            return list;
        }

        public EditViewModel Getdetail(int id)
        {
            var model = _accountRepository.GetbyId(id);
            return new EditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Addres = model.Addres,
                Password = model.Password,
            };
        }
        public AccountViewModel GetBy(int id)
        {
           var model=  _accountRepository.GetbyId(id);
            return Map(model);
          
        }
        public AccountViewModel GetBy(string phone)
        {
            var a = _accountRepository.Getby(phone);
            return Map(a);
        }
       
        public OperationResult login(string? phone, string? password)
        {
            var login= _accountRepository.login(phone, password);
            return login;
        }

        public AccountViewModel Map(Account model)
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
                IsAvalable=model.IsAvalable,
            };
        }

        public AccountViewModel GetdetailInfo(int id)
        {
            var model = _accountRepository.GetbyId(id);
            return new AccountViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Addres = model.Addres,
                Password = model.Password,
            };
        }
    }
}
