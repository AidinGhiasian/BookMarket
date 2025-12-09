using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T entity);
        T GetById(long id);
        public List<T> GetAll();
        void SaveChanges();
    }
}
