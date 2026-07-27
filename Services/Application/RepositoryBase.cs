using Microsoft.EntityFrameworkCore;

namespace Services.Application;

public class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    private readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;
    }

    public void Add(T entity) => _context.Set<T>().Add(entity);

    public T? GetByLongId(long id) => _context.Set<T>().Find(id);

    public T? GetById(int id) => _context.Set<T>().Find(id);

    public List<T> GetAll() => _context.Set<T>().ToList();

    public void SaveChanges() => _context.SaveChanges();

    public async Task SaveChangesAsync(CancellationToken ct = default)
        => await _context.SaveChangesAsync(ct);
}
