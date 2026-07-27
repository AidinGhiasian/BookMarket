using BlogM.Application.Contracts.EventApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Event
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IEventApplication _eventApplication;
        public IndexModel(IEventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }

        public List<EventViewModel> Events { get; set; } = new();

        public void OnGet()
        {
            Events = _eventApplication.GetAll();
        }

        public IActionResult OnPostDelete(long id)
        {
            _eventApplication.Delete(id);
            TempData["danger"] = "رویداد با موفقیت حذف شد.";
            return RedirectToPage();
        }
    }
}
