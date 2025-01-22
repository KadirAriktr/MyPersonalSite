using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MyPersonalSite.Areas.Writer.Controllers
{
    public class DashboardController :Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [Area("Writer")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = values.Name+" "+values.Surname;
            //Weather Api
            string api = "52ec78aff8ef119f6775fdfa6e34e8a1";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=kocaeli&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v5 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            // Statistics
            Context c = new Context();
            ViewBag.v1 = c.Users.Count();
            ViewBag.v2 = c.Announcements.Count();
            ViewBag.v3 = c.WriterMessages.Where(x => x.Receiver == values.Email).Count();
            ViewBag.v4 = c.WriterMessages.Where(x => x.Sender == values.Email).Count();

            return View();
        }
    }
}
//https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=52ec78aff8ef119f6775fdfa6e34e8a1