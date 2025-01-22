using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş geçilemez!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel alanı boş geçilemez!");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel alanı boş geçilemez!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez!");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer alanı boş geçilemez!");
            RuleFor(x => x.Value).InclusiveBetween(0, 100).WithMessage("0-100 arasında olmalıdır.");
            RuleFor(x => x.Name).MinimumLength(5).MaximumLength(100).WithMessage("Proje adı en az 5, en fazla 100 karakter olabilir.");
        }
    }
}
