using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        FeatureManager _featureManager = new FeatureManager(new EfFeature());

     

        [HttpGet]
        public IActionResult Index()
        {
            var values = _featureManager.TGetById(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Feature feature) 
        {
            _featureManager.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }
        
    }
}
