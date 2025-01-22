using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Experience2Controller : Controller
    {
        ExperienceManager _experienceManager = new ExperienceManager(new EfExperience());

        public Experience2Controller(ExperienceManager experienceManager)
        {
            _experienceManager = experienceManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(_experienceManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            
            if (string.IsNullOrEmpty(p.ImageUrl))
            {
                p.ImageUrl = "default-image.jpg"; 
            }

            
            if (string.IsNullOrEmpty(p.Description))
            {
                p.Description = "Açıklama eklenmedi.";
            }

            _experienceManager.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceId)
        {
            var v = _experienceManager.TGetById(ExperienceId);
            var values = JsonConvert.SerializeObject(v);
            return Json(values);
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = _experienceManager.TGetById(id);
            _experienceManager.TDelete(values);
            return NoContent();
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience p)
        {

            if (string.IsNullOrEmpty(p.ImageUrl))
            {
                p.ImageUrl = "default-image.jpg"; 
            }

            
            if (string.IsNullOrEmpty(p.Description))
            {
                p.Description = "Açıklama eklenmedi.";
            }

            _experienceManager.TUpdate(p); 
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

    }
}
