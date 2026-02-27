using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;

namespace BookM.Application.Contracts.BooksCategoryApplication
{
    public class BookCategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }        
        public DateTime CreatedAt { get; set; }
        public string Picture { get; set; }
        public List<Books> Books { get;  set; } = new List<Books>();

    }
}
