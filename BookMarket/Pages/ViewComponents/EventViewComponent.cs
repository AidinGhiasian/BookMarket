using BookM.ClientQueries.Model.Blog.Event;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Pages.ViewComponents
{
    public class EventViewComponent:ViewComponent
    {
        private readonly IEventQueries _eventQueries;
        public EventViewComponent(IEventQueries eventQueries)
        {
            _eventQueries= eventQueries;
        }
        public IViewComponentResult Invoke()
        {
            var events = _eventQueries.Events().First();//متد Events متد getAll است
            return View(events);
        }
    }
}
//کد ,فرست اینجا اولین رویدادی که در دیتابیس بر بخورد را گت میکند 