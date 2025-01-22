using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager messageManager = new WriterMessageManager(new EfWriterMessage());
        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = messageManager.GetListReceiverMessage(p);
            return View(messageList);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = messageManager.GetListSenderMessage(p);
            return View(messageList);
        }
        [Authorize]
        [Route("MessageDetails/{id}")]
        public async Task<IActionResult> MessageDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ID");
            }
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string currentUserMail = currentUser.Email;
            WriterMessage writerMessage = messageManager.TGetById(id);

            if (writerMessage == null|| writerMessage.Sender!=currentUserMail)
            {
                return Forbid();
            }

            return View(writerMessage);
        }

        [Authorize]
        [Route("ReceiverMessageDetails/{id}")]
        public async Task<IActionResult> ReceiverMessageDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Geçersiz ID");
            }

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            string currentUserMail = currentUser.Email;
            WriterMessage writerMessage = messageManager.TGetById(id);

            if (writerMessage == null || writerMessage.Receiver != currentUserMail)
            {
                return Forbid();
            }

            return View(writerMessage);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
           
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = DateTime.Now;
            p.Sender = mail;
            p.SenderName = name;

            Context c = new Context();
            var receiverUser = c.Users
                .Where(x => x.Email == p.Receiver)
                .Select(y => new { y.Name, y.Surname })
                .FirstOrDefault();


            if (receiverUser == null)
            {
                TempData["ErrorMessage"] = "Gönderdiğiniz e-posta adresi sistemde kayıtlı değil.";
                return RedirectToAction("SendMessage");
            }
            p.ReceiverName = receiverUser.Name + " " + receiverUser.Surname;
            messageManager.TAdd(p);
            return RedirectToAction("SenderMessage");
        }


    }
}

