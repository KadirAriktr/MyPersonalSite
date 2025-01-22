using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace MyPersonalSite.Controllers
{
    public class AnnouncementController : Controller
    {
        AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncement());

       

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Announcement announcement)
        {
            ModelState.Clear();
            AnnouncementValidator validations = new AnnouncementValidator();
            ValidationResult result = validations.Validate(announcement);
            if (result.IsValid)
            {
                _announcementManager.TAdd(announcement);
                return RedirectToAction("GetList", "Announcement");
            }
            else
            {
                
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(announcement);
        }
        public IActionResult DeleteAnnouncement(int id) 
        {
            var values=_announcementManager.TGetById(id);
            _announcementManager.TDelete(values);
            return RedirectToAction("GetList", "Announcement");
        }
        public IActionResult GetList()
        {
            var values=_announcementManager.TGetList();
            return View(values);  
        }
        [HttpGet]
        public IActionResult EditAnnouncement(int id) 
        {
            var values = _announcementManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement announcement)
        {
            _announcementManager.TUpdate(announcement);
            return RedirectToAction("GetList", "Announcement");
        }


    }
}
