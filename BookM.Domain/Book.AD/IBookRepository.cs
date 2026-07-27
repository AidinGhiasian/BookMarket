using Services.Application;

namespace BookM.Domain.Book.AD
{
    public interface IBookRepository : IRepositoryBase<Books>
    {
        void Create(Books books);
        Books? GetById(int id);
        Task Updateby(Books book);
        Books? Getby(string Title);
        void Delete(int id);
        List<Books> GetBy();
        List<Books> GetBy(string title);
        List<Books> GetAllWithCategory();
    }
}
