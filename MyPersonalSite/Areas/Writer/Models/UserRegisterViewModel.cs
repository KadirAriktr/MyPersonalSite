using System.ComponentModel.DataAnnotations;

namespace MyPersonalSite.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler Uyumlu Değildir")]
        public string ConfirmPassword { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Mail { get; set; }

 
        public string ImageUrl { get; set; }
    }
}
