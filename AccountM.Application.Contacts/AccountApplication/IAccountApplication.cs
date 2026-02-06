namespace AccountM.Application.Contacts.AccountApplication
{
    public interface IAccountApplication
    {
        public void Create(CreateViewModel model);
        public void Edit(EditViewModel model);
        public AccountViewModel GetBy(int id);
        List<AccountViewModel> GetAccounts(bool isStatus);
        public void Delete(int id);
        public void Restore(int id);
        public AccountViewModel GetBy(string phone);
        public bool login(string? email, string? password);
        public List<AccountViewModel> GetAll();
        public EditViewModel Getdetail(int id);
    }
}
