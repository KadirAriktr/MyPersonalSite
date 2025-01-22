using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager _experienceManager = new ExperienceManager(new EfExperience());

        

        public IActionResult Index()
        {
            var values = _experienceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience) 
        {
            ModelState.Clear();
            ExperienceValidator validationRules = new ExperienceValidator();
            ValidationResult result = validationRules.Validate(experience);
            if (result.IsValid)
            {
                _experienceManager.TAdd(experience);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
          
            return View();
        }
        public IActionResult DeleteExperience(int id) 
        {
            var values=_experienceManager.TGetById(id);
            _experienceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            
            var values = _experienceManager.TGetById(id);
            return View(values);
        
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            ModelState.Clear();
            ExperienceValidator validationRules=new ExperienceValidator();
            ValidationResult result=validationRules.Validate(experience);
            if (result.IsValid)
            {
                _experienceManager.TUpdate(experience);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();



        }
    }
}
