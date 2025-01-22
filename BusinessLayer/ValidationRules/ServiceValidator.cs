using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Hizmet adı boş geçilemez!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolu boş geçilemez!");
        }
    }
}
