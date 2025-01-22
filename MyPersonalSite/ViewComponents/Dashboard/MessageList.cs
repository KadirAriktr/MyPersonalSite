using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EfMessage());
        
        public IViewComponentResult Invoke()
        {
            var values = messageManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
