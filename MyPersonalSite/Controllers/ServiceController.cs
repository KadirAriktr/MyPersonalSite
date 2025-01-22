using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using FluentValidation;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        ServiceManager _serviceManager=new ServiceManager(new EfService());

        public ServiceController(ServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
           
            var values = _serviceManager.TGetList();
            return View(values);
        }
        
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            ModelState.Clear();

            ServiceValidator validations = new ServiceValidator();
            ValidationResult results = validations.Validate(service);
            if (results.IsValid)
            {
                _serviceManager.TAdd(service);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }
            return View();
        }
        public IActionResult DeleteService(int id)
        {
            var values = _serviceManager.TGetById(id);
            _serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            var values = _serviceManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            ModelState.Clear();
            ServiceValidator validations = new ServiceValidator();
            ValidationResult result = validations.Validate(service);
            if (result.IsValid)
            {
                _serviceManager.TUpdate(service);
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
