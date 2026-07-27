using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookM.Application.Contracts.BooksApplication
{
    public class BookCategoryEditViewModel:BookCategoryCreateViewModel
    {
        public int Id { get; set; }
        public string PictureName { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
