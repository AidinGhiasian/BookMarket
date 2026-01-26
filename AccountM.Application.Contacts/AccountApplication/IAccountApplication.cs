namespace AccountM.Application.Contacts.AccountApplication
{
    public interface IAccountApplication
    {
        public void Create(CreateViewModel model);
        public void Edit(EditViewModel model);
        public AccountViewModel GetBy(int id);
        List<AccountViewModel> GetAccounts(string? name, string? phone);
        public void Delete(int id);
        public AccountViewModel GetBy(string phone);
    }
}
