using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Dashboard
{
    public class AdminNotification:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
