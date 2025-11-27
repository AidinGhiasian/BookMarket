namespace AccountM.Application.Contacts.AccountApplication
{
    public interface IAccountApplication
    {
        public void Create(CreateViewModel model);
        public void Edit(EditViewModel model);
        public AccountViewModel GetBy(int id);
        List<AccountViewModel> GetAccounts();
        public void Delete(int id);
    }
}
