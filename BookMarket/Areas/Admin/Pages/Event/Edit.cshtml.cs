using BlogM.Application.Contracts.EventApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookMarket.Areas.Admin.Pages.Event
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IEventApplication _eventApplication;
        public EditModel(IEventApplication eventApplication)
        {
            _eventApplication = eventApplication;
        }
        public EditViewModel? Events { get; set; }

        public void OnGet(long id)
        {
            Events = _eventApplication.GetDetail(id);
        }

        public IActionResult OnPost(EditViewModel command)
        {
            if (!ModelState.IsValid)
            {
                Events = command;
                return Page();
            }
            try
            {
                _eventApplication.Update(command);
                TempData["success"] = "رویداد ویرایش شد.";
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                Events = command;
                return Page();
            }
        }
    }
}
