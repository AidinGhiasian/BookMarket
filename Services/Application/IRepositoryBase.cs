namespace Services.Application
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        T? GetByLongId(long id);
        T? GetById(int id);
        List<T> GetAll();
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
