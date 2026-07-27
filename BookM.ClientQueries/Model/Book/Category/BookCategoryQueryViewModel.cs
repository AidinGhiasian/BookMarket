using System;
using System.Collections.Generic;

namespace BookM.ClientQueries.Model.Book.Category
{
    public class BookCategoryQueryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Picture { get; set; }
        public int BookCount { get; set; }
    }
}
