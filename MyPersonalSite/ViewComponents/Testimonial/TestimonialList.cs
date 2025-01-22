using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Testimonial
{
    public class TestimonialList:ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonial());
        public IViewComponentResult Invoke()
        {
            var result=testimonialManager.TGetList();
            return View(result);
        }
    }
}
