using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPersonalSite.Areas.Writer.Models;
using System.IO;
using System.Threading.Tasks;

namespace MyPersonalSite.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel
            {
                Name = values.Name,
                Surname = values.Surname,
                PictureURL = values.ImageUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            // ModelState kontrolü ekleyelim
            if (!ModelState.IsValid)
            {
                return View(p); // Geçersiz model durumunda aynı sayfayı tekrar yükle
            }

            // Kullanıcı resmini güncelleme
            if (p.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }

            // Kullanıcı bilgilerini güncelleme
            user.Name = p.Name;
            user.Surname = p.Surname;

            // Şifreyi boş geçmemek için kontrol
            if (!string.IsNullOrEmpty(p.Password))
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }

            // Kullanıcıyı güncelleme
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(p); // Güncelleme başarısızsa kullanıcıyı formu yeniden göstermeli
        }
    }
}
