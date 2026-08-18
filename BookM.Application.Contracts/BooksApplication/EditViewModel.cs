using BookM.Application.Contracts.BooksCategoryApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.Application.Contracts.BooksApplication
{
    public class EditViewModel:CreateViewModel
    {
        public int Id { get; set; }
        public bool status {  get; set; }
        public string Picture { get; set; }
        public string Categorey { get; set; }
        public List<BookCategoryViewModel> BookCategories { get; set; }
    }
}
