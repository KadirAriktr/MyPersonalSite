using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessage());

        public ContactController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        public IActionResult Index()
        {
            var values = _messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
           var values=_messageManager.TGetById(id);
           _messageManager.TDelete(values);
            return RedirectToAction("Index","Contact");
        }
        public IActionResult ContactDetails(int id)
        {
            var values= _messageManager.TGetById(id);
            return View(values);
        }
    }
}
