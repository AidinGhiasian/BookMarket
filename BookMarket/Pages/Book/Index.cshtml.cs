using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.ClientQueries.Model.Book.Books;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages.Book
{
    public class IndexModel : PageModel
    {
        public List<BookQueryViewModel> Books { get; set; }
        public List<BookQueryViewModel> BooksWithCategory { get; set; }
        public List<BookCategoryQueryViewModel> Categories { get; set; }

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

            if (id != null && id != 0)
            {
                BooksWithCategory = _bookQueries.GetAllBookWithCategory(id);
            }
            else
            {
                Books = _bookQueries.GetAll();
                if (Books.Count == 0)
                {
                    TempData["information"] = "هیچ مقاله ای وجود ندارد...";
                }
            }
        }
    }
}
