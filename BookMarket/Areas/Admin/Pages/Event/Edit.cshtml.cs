using BlogM.Application.Contacts.EventApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Event
{
    public class EditModel : PageModel
    {
        private readonly IEventApplication _eventApplication;
        public EditModel(IEventApplication eventApplication)
        {
            _eventApplication=eventApplication;
        }
        public EditViewModel Events { get; set; }
        public void OnGet(int id)
        {
            Events = _eventApplication.Getdetail(id);
        }
        public IActionResult OnPost(EditViewModel command)
        {
            _eventApplication.Update(command);
            return Redirect("./Index");
        }
    }
}
