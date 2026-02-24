using BlogM.Application.Contracts.EventApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Event
{
    public class IndexModel : PageModel
    {

        private readonly IEventApplication _eventApplication;
        public IndexModel(IEventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }
        public List<EventViewModel> Events { get; set; }
        public void OnGet()
        {
            Events = _eventApplication.GetAll();
        }
        public IActionResult OnGetDelete(int id)
        { 
         _eventApplication.Delete(id);
            TempData["danger"] = "رویداد یا موفقیت حذف شد";
            return RedirectToPage("./Index");
        }


    }
}




