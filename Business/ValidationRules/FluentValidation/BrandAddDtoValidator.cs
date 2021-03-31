using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class BrandAddDtoValidator:AbstractValidator<BrandAddDto>
    {
        public BrandAddDtoValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty()
                .WithMessage("Marka Adı Boş Olamaz");
        }
    }
}
