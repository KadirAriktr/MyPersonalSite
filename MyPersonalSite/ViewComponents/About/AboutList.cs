using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EfAbout());
        public IViewComponentResult Invoke()
        {

            var values = aboutManager.TGetList();
            return View(values);
        }
    }
}
