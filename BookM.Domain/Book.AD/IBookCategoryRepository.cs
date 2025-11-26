using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.Domain.Book.AD
{
    public interface IBookCategoryRepository
    {
        public void Create(BookCategories Create);
        public BookCategories? GetById(long  id);
        public void Edit(BookCategories Update);
        public List<BookCategories> GetAll();
        public void Delete(long id);
    }
}
