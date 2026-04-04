using Services.Application;


namespace BookM.Domain.Book.AD
{
    public interface IBookRepository:IRepositoryBase<Books>
    {

        public void Create(Books books);
        public Books? GetById(int id);
        Task Updateby(Books book);
        public Books Getby(string Title);
        public void Delete(int id);
       
        public List<Books> GetBy();

        public List<Books> GetBy(string title);

    }
}
