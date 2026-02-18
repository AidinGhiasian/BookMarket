using BlogM.Application.Contacts.EventApplication;
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

    }
}




