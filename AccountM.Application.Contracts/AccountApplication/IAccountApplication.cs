using Microsoft.OpenApi.Validations.Rules;
using Services.Application;

namespace AccountM.Application.Contracts.AccountApplication
{
    public interface IAccountApplication
    {
        public OperationResult Create(CreateViewModel model);
        public OperationResult Edit(EditViewModel model);
        public AccountViewModel GetBy(int id);
        List<AccountViewModel> GetAccounts(bool isStatus);
        public OperationResult Delete(int id);
        public OperationResult Restore(int id);
        public AccountViewModel GetBy(string phone);
        public OperationResult login(string? phone, string? password);
        public List<AccountViewModel> GetAll();
        public EditViewModel Getdetail(int id);
        public AccountViewModel GetdetailInfo(int id);
        public OperationResult Logout();
        public OperationResult ChangePassword(PasswordViewModel command);
        public OperationResult ChangeRole(int id, int roleId);
    }
}
