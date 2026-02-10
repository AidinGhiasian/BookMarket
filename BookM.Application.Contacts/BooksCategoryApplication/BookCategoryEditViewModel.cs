using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.Application.Contacts.BooksApplication
{
    public class BookCategoryEditViewModel:BookCategoryCreateViewModel
    {
        public int Id { get; set; }
        public string pictureName { get; set; }
    }
}
