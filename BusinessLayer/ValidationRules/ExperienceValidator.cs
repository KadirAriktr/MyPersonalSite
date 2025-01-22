using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator : AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Deneyim İsmi Boş Geçilemez");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Deneyim Tarihi Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Deneyim Açıklaması Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Deneyim URL Boş Geçilemez");

        }
    }
}
