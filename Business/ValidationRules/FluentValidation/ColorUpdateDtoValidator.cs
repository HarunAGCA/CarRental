using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorUpdateDtoValidator : AbstractValidator<ColorUpdateDto>
    {
        public ColorUpdateDtoValidator()
        {

            RuleFor(c => c.Id).NotEmpty().WithMessage("Id Boş Olamaz");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Renk Adı Boş Olamaz");
        }
    }
}
