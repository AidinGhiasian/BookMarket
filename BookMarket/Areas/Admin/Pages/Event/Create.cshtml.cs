using BlogM.Application.Contacts.EventApplication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Event
{
    public class CreateModel : PageModel
    {
        private readonly IEventApplication _eventApplication;
        public CreateModel(IEventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }
        public CreateViewModel Events { get; set; }
        public void OnGet()
        {
            
        }
        public IActionResult OnPost(CreateViewModel command) 
        { 
        _eventApplication.Create(command);
            TempData["success"] = "رویداد با موفقیت ثبت شد.";
         return   Redirect("./Index");
        }
    }
}

