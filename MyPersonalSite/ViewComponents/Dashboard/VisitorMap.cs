using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Dashboard
{
    public class VisitorMap:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
