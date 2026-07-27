using AccountM.Application.Contracts.AccountApplication;
using BookM.ClientQueries.Model.Account;
using Services.Application;

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

        public AccountViewModel? Account(int id)
        {
            var model = _accountApplication.GetBy(id);
            if (model == null) return null;
            return new AccountViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                cratetiondate = model.cratetiondate,
                Addres = model.Addres,
                IsAvalable = model.IsAvalable,
            };
        }

        public AccountViewModel? Account(string phoneNumber)
        {
            var model = _accountApplication.GetBy(phoneNumber);
            if (model == null) return null;
            return new AccountViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                cratetiondate = model.cratetiondate,
                Addres = model.Addres,
                IsAvalable = model.IsAvalable,
            };
        }

        public EditViewModel? GetDetail(int id)
        {
            var model = _accountApplication.Getdetail(id);
            if (model == null) return null;
            return new EditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Addres = model.Addres,
                PhoneNumber = model.PhoneNumber,
                PictureName = model.PictureName,
                RoleId = model.RoleId,
            };
        }

        public EditViewModel? GetDetail(string phone)
        {
            var model = _accountApplication.GetBy(phone);
            if (model == null) return null;
            return new EditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Addres = model.Addres,
                PhoneNumber = model.PhoneNumber,
                PictureName = model.Picture,
            };
        }

        public Task<OperationResult> Login(string? phone, string? password)
            => _accountApplication.LoginAsync(phone, password);

        public Task<OperationResult> Register(CreateViewModel model)
        {
            try
            {
                _accountApplication.Create(model);
                return Task.FromResult(new OperationResult().IsSuccess("ثبت نام با موفقیت انجام شد."));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new OperationResult().Failed(ex.Message));
            }
        }
    }
}
