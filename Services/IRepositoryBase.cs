using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        T GetById(long id);
        public List<T> GetAll();
        void SaveChanges();
    }
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
}
