using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;

namespace BookM.Application.Contacts.BooksApplication
{
    public interface IBookApplication
    {
        void Create(CreateViewModel create);
        Books? GetById(int id);
        void Edit(EditViewModel update);
        void Delete(int id);
        public List<BookViewModel> GetAll();
        public EditViewModel Getdetail(int id);
    }
}
