using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TestimonialValidator:AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.ClientName).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.Company).NotEmpty().WithMessage("Şirket İsmi Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim Yolu Boş Geçilemez");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum Boş Geçilemez");

        }
    }
}
