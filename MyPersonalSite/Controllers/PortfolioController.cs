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
    public class PortfolioController : Controller
    {
        PortfolioManager _portfolioManager = new PortfolioManager(new EfPortfolio());

     

        public IActionResult Index()
        {
            var values=_portfolioManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            ModelState.Clear();
            
            PortfolioValidator validations= new PortfolioValidator();
            ValidationResult results=validations.Validate(portfolio);
            if (results.IsValid) 
            {
                _portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage); 
                }

            }
            return View();
           
        }
        public IActionResult DeletePortfolio(int id)
        {
            var values= _portfolioManager.TGetById(id);
            _portfolioManager.TDelete(values);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            var values = _portfolioManager.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            ModelState.Clear();

            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results=validations.Validate(portfolio);
            if (results.IsValid)
            {
               
                _portfolioManager.TUpdate(portfolio);
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
    }
}
