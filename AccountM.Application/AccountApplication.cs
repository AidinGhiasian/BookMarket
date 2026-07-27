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
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRoleRepository _roleRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(
            IAccountRepository accountRepository,
            IPasswordHasher passwordHasher,
            IRoleRepository roleRepository,
            IFileUploader fileUploader,
            IAuthHelper authHelper)
        {
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _authHelper = authHelper;
        }

        public void Create(CreateViewModel model)
        {
            string picture = "";
            if (model.FilePicture != null)
            {
                picture = _fileUploader.UploadNewSize(model.FilePicture, "Account", 720);
            }
            var password = _passwordHasher.Hash(model.Password);

            var acc = new Account(
                model.Name,
                model.Family,
                model.PhoneNumber,
                string.IsNullOrWhiteSpace(model.Email) ? "" : model.Email,
                model.BirthDate,
                string.IsNullOrWhiteSpace(model.Addres) ? "" : model.Addres,
                password,
                Roles.UserId,
                picture
            );
            _accountRepository.Create(acc);
        }

        public void Delete(int id) => _accountRepository.Delete(id);
        public void Restore(int id) => _accountRepository.Restore(id);

        public void Edit(EditViewModel model)
        {
            var acc = _accountRepository.GetbyId(model.Id)
                ?? throw new InvalidOperationException(ApplicationMessage.NotFound);

            var pictureName = acc.Picture ?? "";
            if (model.FilePicture != null)
            {
                if (!string.IsNullOrWhiteSpace(acc.Picture))
                    _fileUploader.Delete(acc.Picture);

                pictureName = _fileUploader.UploadNewSize(model.FilePicture, "Account", 720);
            }

            acc.Edit(
                model.Name,
                model.Family,
                model.PhoneNumber,
                model.Email,
                model.BirthDate,
                model.Addres,
                model.RoleId,
                pictureName
            );

            _accountRepository.SaveChanges();
        }

        public List<AccountViewModel> GetAccounts(bool isStatus)
            => _accountRepository.GetAccounts(isStatus).Select(Map).ToList();

        public List<AccountViewModel> GetAll()
            => _accountRepository.GetAll().Select(Map).ToList();

        public EditViewModel Getdetail(int id)
        {
            var model = _accountRepository.GetbyId(id);
            if (model == null) throw new InvalidOperationException(ApplicationMessage.NotFound);
            return new EditViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Family = model.Family,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Addres = model.Addres,
                PictureName = model.Picture,
                RoleId = model.RoleId,
            };
        }

        public AccountViewModel GetBy(int id)
        {
            var model = _accountRepository.GetbyId(id);
            return model == null ? null : Map(model);
        }

        public AccountViewModel GetBy(string phone)
        {
            var a = _accountRepository.Getby(phone);
            return a == null ? null : Map(a);
        }

        public async Task<OperationResult> LoginAsync(string? phone, string? password)
        {
            var operation = new OperationResult();
            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
                return operation.Failed("شماره همراه یا رمز عبور وارد نشده است.");

            var account = _accountRepository.Getby(phone);
            if (account == null)
                return operation.Failed(ApplicationMessage.NotFound);

            if (!account.IsAvalable)
                return operation.Failed("حساب کاربری شما غیرفعال است.");

            var (verified, needsUpgrade) = _passwordHasher.Check(account.Password, password);
            if (!verified)
                return operation.Failed(ApplicationMessage.NotFound);

            var role = _roleRepository.GetDetails(account.RoleId);
            if (role == null)
                return operation.Failed("نقش کاربری شما یافت نشد.");
            var permissions = role?.Permissions.Select(x => x.PermissionCode).ToList() ?? new List<int>();

            var fullName = $"{account.Name} {account.Family}";
            var authViewModel = new AuthViewModel(
                account.Id, account.RoleId, fullName, account.PhoneNumber,
                account.PhoneNumber, permissions, account.Picture ?? "", account.Addres ?? "", account.IsAvalable);

            await _authHelper.SigninAsync(authViewModel);

            if (needsUpgrade)
            {
                account.ChangePassword(_passwordHasher.Hash(password));
                _accountRepository.SaveChanges();
            }

            return operation.IsSuccess("ورود موفقیت‌آمیز.");
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
                IsAvalable = model.IsAvalable,
                Picture = model.Picture,
            };
        }

        public AccountViewModel GetdetailInfo(int id)
        {
            var model = _accountRepository.GetbyId(id);
            return model == null ? null : Map(model);
        }

        public async Task LogoutAsync()
        {
            await _authHelper.SignOutAsync();
        }

        public OperationResult ChangePassword(PasswordViewModel command)
        {
            var operation = new OperationResult();

            if (command.Id <= 0 || string.IsNullOrWhiteSpace(command.Password) || string.IsNullOrWhiteSpace(command.RePassword))
                return operation.Failed(ApplicationMessage.NotFound);

            if (command.Password != command.RePassword)
                return operation.Failed("رمز عبور و تکرار آن یکسان نیست.");

            var account = _accountRepository.GetbyId(command.Id);
            if (account == null) return operation.Failed(ApplicationMessage.NotFound);

            account.ChangePassword(_passwordHasher.Hash(command.Password));
            _accountRepository.SaveChanges();

            return operation.IsSuccess("رمز عبور با موفقیت تغییر یافت.");
        }
    }
}
