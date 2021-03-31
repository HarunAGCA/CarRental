using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorAddDtoValidator:AbstractValidator<ColorAddDto>
    {
        public ColorAddDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Renk Adı Boş Olamaz");
        }
    }
}
