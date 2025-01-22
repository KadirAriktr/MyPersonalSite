using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncement());
        public IActionResult Index()
        {
            var values=announcementManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ID");
            }

            Announcement announcement = announcementManager.TGetById(id);
            if (announcement == null)
            {
                return NotFound("Duyuru bulunamadı");
            }

            return View(announcement);
        }
    }
}
