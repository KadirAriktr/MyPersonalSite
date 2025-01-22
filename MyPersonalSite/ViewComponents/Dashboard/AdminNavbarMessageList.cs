using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.ViewComponents.Dashboard
{
    public class AdminNavbarMessageList:ViewComponent
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessage());
        public IViewComponentResult Invoke()
        {
            

            string p = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x => x.WriterMessageID).Take(3).ToList();
            Context c = new Context();
            foreach (var items in values)
            {
                var img=c.Users.Where(x=>x.Email==items.Sender).Select(x=>x.ImageUrl).FirstOrDefault();
                items.ImageUrl = img;
            }
            return View(values);  
        }
    }
}
