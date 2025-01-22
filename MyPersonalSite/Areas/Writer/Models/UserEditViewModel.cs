using System.ComponentModel.DataAnnotations;

namespace MyPersonalSite.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş geçilemez!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez!")]
        [StringLength(100, ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Tekrar Şifre alanı boş geçilemez!")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string PasswordConfirm { get; set; }

        public string PictureURL { get; set; }
        public IFormFile Picture { get; set; }
    }
}
