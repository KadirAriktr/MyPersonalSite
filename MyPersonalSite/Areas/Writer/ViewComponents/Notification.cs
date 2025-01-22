using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Areas.Writer.ViewComponents
{
    public class Notification:ViewComponent
    {
        AnnouncementManager announcementManager=new AnnouncementManager(new EfAnnouncement());
        public IViewComponentResult Invoke()
        {
            var values=announcementManager.TGetList().Take(6).ToList();
            return View(values);
        }
    }
}
