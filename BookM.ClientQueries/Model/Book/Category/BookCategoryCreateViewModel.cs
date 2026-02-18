using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.ClientQueries.Model.Book.Books;
using BookM.Domain.Book.AD;
using Microsoft.AspNetCore.Http;

namespace BookM.ClientQueries.Model.Book.Category
{
    public class BookCategoryQueryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string picture { get; set; }
        public List<BookQueryViewModel> Books { get; set; } = new List<BookQueryViewModel>();


    }
}
