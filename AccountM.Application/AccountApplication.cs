using AccountM.Application.Contracts.AccountApplication;
using AccountManagement.Domain.RoleAgg;
using AM.Domain.Account.AD;
using Services.Application;
using Services.Application.AuthHelper;
using Services.Application.Categoreis;
using Services.Application.HashPassword;

namespace AccountM.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        public IPasswordHasher _PasswordHasher;
        public IRoleRepository _roleRepository;
        private readonly IFileUploader _fileUploder;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IAccountRepository accountRepository
            , IPasswordHasher passwordHasher,
            IRoleRepository roleRepository
            , IFileUploader fileUploader,
            IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _PasswordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _fileUploder = fileUploader;
            _authHelper = authHelper;
        }

        public void Create(CreateViewModel model)
        {
            string picture = "";
            if (model.FilePicture != null)
            {
                var path = "Account";
                 picture = _fileUploder.UploadNewSize(model.FilePicture, path, 720);
            }
            var password = _PasswordHasher.Hash(model.Password);

            var acc = new Account(
                model.Name,
                model.Family,
                model.PhoneNumber,
                model.Email,
                model.BirthDate,
                model.Address,
               password, Convert.ToInt32(Roles.User),
             picture
            );
            _accountRepository.Create(acc);
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
            if (model.FilePicture != null)
            {
                _fileUploder.Delete(model.PictureName);

                var path = "Account";
                model.PictureName = _fileUploder.UploadNewSize(model.FilePicture, path, 720);
            }
            acc.Edit(
                model.Name,
                model.Family,
                model.PhoneNumber,
                model.Email,
                model.BirthDate,
                model.Address,
                model.PictureName
            );


            _accountRepository.SaveChanges();
        }

        public List<AccountViewModel> GetAccounts(bool isStatus)
        {
            return _accountRepository.GetAccounts(isStatus).Select(Map).ToList();

        }
        public List<AccountViewModel> GetAll()
        {
            var accounts = _accountRepository.GetAll();
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
                Address = model.Address,
            };
        }
        public AccountViewModel GetBy(int id)
        {
            var model = _accountRepository.GetbyId(id);
            return Map(model);

        }
        public AccountViewModel GetBy(string phone)
        {
            var a = _accountRepository.Getby(phone);
            return Map(a);
        }

        public OperationResult login(string? phone, string? password)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Getby(phone);

            if (account == null)
               return operation.Failed(ApplicationMessage.NotFound);

            (bool Verified, bool NeedUpgrade) result = _PasswordHasher.Check(account.Password, password);

            if (!result.Verified)
                 return  operation.Failed(ApplicationMessage.NotFound);

            var permissions = _roleRepository.GetDetails(account.RoleId).Permissions.Select(x => x.PermissionCode).ToList();



            var fulName = account.Name + " " + account.Family;
            var authViewModel = new AuthViewModel(account.Id, account.RoleId, fulName, account.PhoneNumber,
               account.PhoneNumber, permissions, account.Picture, account.Address, account.IsAvalable);
            _authHelper.Signin(authViewModel);
            return operation.IsSuccess();
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
                Address = model.Address,
                IsAvalable = model.IsAvalable,
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
                Address = model.Address,
            };
        }
        public void Logout()
        {
            _authHelper.SignOut();
        }

        public OperationResult ChangePassword(PasswordViewModel command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetbyId(command.Id);

            if (account.Id == null || command.Password == null || command.RePassword == null)
            {
                return operation.Failed(ApplicationMessage.NotFound);
            }

            if (command.Password != command.RePassword)
                return operation.Failed("رمز عبور و تکرار آن یکسان نیست.");

            var password = _PasswordHasher.Hash(command.Password);

            account.ChangePassword(password);

            _accountRepository.SaveChanges();

            return operation.IsSuccess();
        }
    }
}