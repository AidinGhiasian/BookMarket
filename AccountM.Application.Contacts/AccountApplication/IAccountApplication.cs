namespace AccountM.Application.Contacts.AccountApplication
{
    public interface IAccountApplication
    {
        public void Create(CreateViewModel model);
        public void Edit(EditViewModel model);
        public AccountViewModel GetDetails(int id);
    }
}
