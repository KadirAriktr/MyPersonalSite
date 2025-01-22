using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        SocialMediaManager _socialMediaManager = new SocialMediaManager(new EfSocialMedia());

        public SocialMediaController(SocialMediaManager socialMediaManager)
        {
            _socialMediaManager = socialMediaManager;
        }

        public IActionResult Index()
        {
            var values=_socialMediaManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia m) 
        {
            m.Status=true;
            _socialMediaManager.TAdd(m);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id) 
        {
            var values=_socialMediaManager.TGetById(id);
            _socialMediaManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            var values=_socialMediaManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSocialMedia(SocialMedia m)
        {
            _socialMediaManager.TUpdate(m);
            return RedirectToAction("Index");
        }
    }
}
