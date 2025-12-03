using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace BookM.Domain.Book.AD
{
    public  interface IBookRepository
    {

        public void Create(Books books);
        public Books? GetById(int id);
        Task Updateby(Books book);
        public Books Getby(string Title);
        public void Delete(int id);
        public List<Books>GetBy(string BookTitle);
    }
}
