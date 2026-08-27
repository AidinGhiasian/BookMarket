using BlogM.Application.Contracts.EventApplication;
using BlogMInfrastructureConfiguration.Permission;
using BookMInfrastucureConfiguration.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Infrastructure;

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

        [NeedsPermission(BlogPermission.EditEvent)]
        public void OnGet(long id)
        {
            Events = _eventApplication.GetDetail(id);
        }
        public IActionResult OnPost(EditViewModel command)
        {
            _eventApplication.Update(command);
            return Redirect("./Index");
        }
        
    }
}
