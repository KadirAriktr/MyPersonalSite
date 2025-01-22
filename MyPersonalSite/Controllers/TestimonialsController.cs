
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
    public class TestimonialsController : Controller
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonial());

     

        public IActionResult Index()
        {
            var values=_testimonialManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteTestimonials(int id)
        {
            var values=_testimonialManager.TGetById(id);
            _testimonialManager.TDelete(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditTestimonials(int id)
        {
            var values = _testimonialManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTestimonials(Testimonial t)
        {
            ModelState.Clear();
            TestimonialValidator validationRules = new TestimonialValidator();
            ValidationResult validationResult = validationRules.Validate(t);
            if (validationResult.IsValid)
            {
                _testimonialManager.TUpdate(t);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddTestimonials()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonials(Testimonial t)
        {
            ModelState.Clear();
            TestimonialValidator validationRules = new TestimonialValidator();
            ValidationResult validationResult = validationRules.Validate(t);
            if (validationResult.IsValid)
            {
                _testimonialManager.TAdd(t);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
