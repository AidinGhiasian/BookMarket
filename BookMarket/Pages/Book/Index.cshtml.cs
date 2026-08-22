using AccountMInfrastructureConfiguration.Permisions;
using BookM.Application.Contracts.BooksCategoryApplication;
using BookM.ClientQueries.Model.Book.Books;
using BookMInfrastucureConfiguration.Permission;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

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
        [NeedsPermission(BookPermission.ListBook)]
        public void OnGet(int? id)
        {
            Categories = _categoryQuery.GetAll();

            if (id != null )
            {
                BooksWithCategory = _bookQueries.GetAllBookWithCategory(id);
            }
            else if(id == null ) 
            {
                Books = _bookQueries.GetAll();
            }
        }
    }
}
