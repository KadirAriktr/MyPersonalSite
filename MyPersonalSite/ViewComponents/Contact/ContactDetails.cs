using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;

namespace MyPersonalSite.ViewComponents.Contact
{
    public class ContactDetails:ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EfContact());        
        public IViewComponentResult Invoke()
        {
            var result = contactManager.TGetList();
            return View(result); 
        }
    }
}
