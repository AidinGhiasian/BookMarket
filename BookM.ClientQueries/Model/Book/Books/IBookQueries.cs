using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.ClientQueries.Model.Book.Books
{
    public interface IBookQueries
    {
        public List<BookQueryViewModel> GetAll();
        public BookQueryViewModel GetDetail(int id);
    }
}
