using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyPersonalSite.Controllers
{
    
    public class DefaultController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeaderPartical()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartical()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult SendMessage(Message p)
        {
            try
            {
                // E-mail doğrulama
                if (string.IsNullOrEmpty(p.Mail) || !new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(p.Mail))
                {
                    return Json(new { success = false, message = "Geçersiz mail adresi." });
                }

                
                MessageManager messageManager = new MessageManager(new EfMessage());
                p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                p.Status = true;
                messageManager.TAdd(p);

                // Başarılı yanıt
                return Json(new { success = true, message = "Mesaj başarıyla gönderildi!" });
            }
            catch (Exception ex)
            {
                // Hata durumunda yanıt
                return Json(new { success = false, message = "Mesaj gönderilirken bir hata oluştu."});
            }
        }
    }
}
