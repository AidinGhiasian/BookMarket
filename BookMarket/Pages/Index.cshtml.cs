using BookM.Application.Contracts.BooksApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Pages
{
    public class IndexModel : PageModel
    {
        public List<BookViewModel> Books { get; set; }
        private readonly IBookApplication _bookApplication;
        public IndexModel(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }
     
        
        public void OnGet()
        {
           Books= _bookApplication.GetAll();
        }
        public void OnGetBook()
        {

        }
    }
}
