using BlogM.Application.Contracts.EventApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Event
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IEventApplication _eventApplication;
        public CreateModel(IEventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }

        [BindProperty] public CreateViewModel? Events { get; set; }
        public void OnGet() { }

        public IActionResult OnPost(CreateViewModel command)
        {
            if (!ModelState.IsValid) return Page();
            try
            {
                _eventApplication.Create(command);
                TempData["success"] = "رویداد با موفقیت ثبت شد.";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return Page();
            }
        }
    }
}
