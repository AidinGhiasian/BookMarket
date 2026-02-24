using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Application;

namespace BookM.Domain.Book.AD
{
    public interface IBookCategoryRepository:IRepositoryBase<BookCategories>
    {
       
      public bool Deleted(int id);
      
    }
}
