using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactSubPlaceController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContact());

    

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactManager.TGetById(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactManager.TUpdate(contact);
            return RedirectToAction("Index","Default");
        }
    }
}
