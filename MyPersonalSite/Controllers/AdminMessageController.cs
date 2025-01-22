using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager _writerMessageManager = new WriterMessageManager(new EfWriterMessage());

        public AdminMessageController(WriterMessageManager writerMessageManager)
        {
            _writerMessageManager = writerMessageManager;
        }

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = _writerMessageManager.TGetById(id);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var values = _writerMessageManager.TGetById(id);
            _writerMessageManager.TDelete(values);
            if (values.Receiver == "admin@gmail.com")
            {
                return RedirectToAction("ReceiverMessageList");
            }
            else
            {
                return RedirectToAction("SenderMessageList");
            }

        }

        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "Admin";
            p.Date=DateTime.Parse(DateTime.Now.ToShortDateString());
            Context c = new Context();
            var usernamesurname = c.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageManager.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
