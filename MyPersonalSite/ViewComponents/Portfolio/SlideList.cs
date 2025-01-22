using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Portfolio
{
    public class SlideList: ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EfPortfolio());

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }
    
    }
}
