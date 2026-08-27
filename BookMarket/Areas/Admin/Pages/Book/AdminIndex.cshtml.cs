using BlogMInfrastructureConfiguration.Permission;
using BookM.Application.Contracts.BooksApplication;
using BookM.Domain.Book.AD;
using BookMInfrastucureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

namespace BookMarket.Areas.Admin.Pages.Book
{
    public class AdminIndexModel : PageModel
    {
        private readonly IBookApplication _bookApplication;
        public AdminIndexModel(IBookApplication bookApplication)
        {
            _bookApplication = bookApplication;
        }
        public List<BookViewModel> Books { get; set; }

        [NeedsPermission(BookPermission.ListBook)]
        public void OnGet()
        {
            Books = _bookApplication.GetAll();
          
        }
        public IActionResult OnGetDelete(int id)
        {
            _bookApplication.Delete(id);
            TempData["danger"] = "کتاب با موفقیت ثبت شد...";
            return Redirect("./AdminIndex");
        }
    }
}
