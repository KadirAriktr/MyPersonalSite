using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        AboutManager _aboutManager = new AboutManager(new EfAbout());

        public AboutController(AboutManager aboutManager)
        {
            _aboutManager = aboutManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _aboutManager.TGetById(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            _aboutManager.TUpdate(about);
            return RedirectToAction("Index","Default");
        }
    }
}
