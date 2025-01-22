using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {
        FeatureManager featureManager=new FeatureManager(new EfFeature());
        public IViewComponentResult Invoke()
        {
            var values=featureManager.TGetList();
            return View(values);
        }
    }
}
