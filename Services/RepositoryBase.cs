using Microsoft.EntityFrameworkCore;

namespace Services;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{

    private readonly DbContext _context;
    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public T GetById(long id)
    {
        return _context.Find<T>();
    }
    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}