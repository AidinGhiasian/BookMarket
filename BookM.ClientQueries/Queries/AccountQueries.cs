using AccountM.Application.Contracts.AccountApplication;
using BookM.ClientQueries.Model.Account;
using DocumentFormat.OpenXml.Office2010.Excel;
using FLEXYGO.GoogleResourceTypes;
using Services.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountViewModel = BookM.ClientQueries.Model.Account.AccountViewModel;
using EditViewModel = BookM.ClientQueries.Model.Account.EditViewModel;

namespace BookM.ClientQueries.Queries
{
    public class AccountQueries : IAccountQueries
    {
        private readonly IAccountApplication _accountApplication;
        private readonly IFileUploader _fileUploader;
        public AccountQueries(IAccountApplication accountApplication, IFileUploader fileUploader)
        {
            _accountApplication = accountApplication;
            _fileUploader = fileUploader;
        }
        public AccountViewModel Account(int id)
        {
            var model = _accountApplication.GetBy(id);
            return new AccountViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                cratetiondate = model.cratetiondate,
                Address = model.Address,
                  IsAvalable = model.IsAvalable,
            };
        }

        public AccountViewModel Account(string phoneNumber)
        {
            var model = _accountApplication.GetBy(phoneNumber);
            return new AccountViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                cratetiondate = model.cratetiondate,
                Address = model.Address,
                                IsAvalable = model.IsAvalable,
            };
        }


        public EditViewModel GetDetail(int id)
        {
            var model = _accountApplication.Getdetail(id);
            return new EditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Address = model.Address,
            };
        }
        public EditViewModel GetDetail(string phone)
        {
            var model = _accountApplication.GetBy(phone);
            return new EditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Address = model.Address,
            };
        }
        public OperationResult Login(string? phone, string? password)
        {
          return _accountApplication.login(phone, password);
        }

        public OperationResult Register(CreateViewModel model)
        {
           _accountApplication.Create(model);
            return new OperationResult().IsSuccess("ثبت نام با موفقیت انجام شد.");
        }
    }
}
