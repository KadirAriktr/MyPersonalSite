using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSite.Areas.Writer.Models;

namespace MyPersonalSite.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            
            var existingUser = await _userManager.FindByEmailAsync(p.Mail);
            if (existingUser != null)
            {
                ModelState.AddModelError("Mail", "Bu e-posta adresi zaten sistemde kayıtlı.");
                return View(p);
            }

            WriterUser w = new WriterUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.UserName,
                ImageUrl = p.ImageUrl
            };

            var result = await _userManager.CreateAsync(w, p.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description); 
                }
            }

            return View(p);
        }
    }
}
