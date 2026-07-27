using BookM.ClientQueries.Model.Book.Books;
using BookM.ClientQueries.Model.Book.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Book
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        public List<BookQueryViewModel> Books { get; set; } = new();
        public List<BookQueryViewModel> BooksWithCategory { get; set; } = new();
        public List<BookCategoryQueryViewModel> Categories { get; set; } = new();

        private readonly IBookCategoryQuery _categoryQuery;
        private readonly IBookQueries _bookQueries;

        public IndexModel(IBookCategoryQuery categoryQuery, IBookQueries bookQueries)
        {
            _bookQueries = bookQueries;
            _categoryQuery = categoryQuery;
        }

        public void OnGet(int? id)
        {
            Categories = _categoryQuery.GetAll();

            if (id.HasValue)
                BooksWithCategory = _bookQueries.GetAllBookWithCategory(id);
            else
                Books = _bookQueries.GetAll();
        }
    }
}

