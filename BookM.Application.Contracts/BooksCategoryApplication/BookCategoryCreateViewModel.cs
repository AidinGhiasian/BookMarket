using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookM.Domain.Book.AD;
using Microsoft.AspNetCore.Http;

namespace BookM.Application.Contracts.BooksApplication
{
    public class BookCategoryCreateViewModel
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public IFormFile? FileName { get; set; }
    }
}
