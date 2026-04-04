using Humanizer;
using Microsoft.AspNetCore.Mvc;

namespace BookMarket.Areas.Admin.Pages.ViewComponents
{
    public class _TopMenuViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
