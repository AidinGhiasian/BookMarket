using BookM.ClientQueries.Model.Blog.Event;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Areas.Admin.Pages.ViewComponents
{
    public class AdminEventBannerViewComponent:ViewComponent
    {
        private readonly IEventQueries _eventQueries;
        public AdminEventBannerViewComponent(IEventQueries eventQueries)
        {
            _eventQueries= eventQueries;
        }

        public IViewComponentResult Invoke()
        {
            var events = _eventQueries.Events().Take(3).ToList();
            return View(events);
        }
    }
}
