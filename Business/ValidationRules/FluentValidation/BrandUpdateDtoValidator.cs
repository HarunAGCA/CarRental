using Core.Entities;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandUpdateDtoValidator : AbstractValidator<BrandUpdateDto>
    {
        public BrandUpdateDtoValidator()
        {

            RuleFor(b => b.Id)
            .NotEmpty()
             .WithMessage("Id Boş Olamaz");

            RuleFor(b => b.Name)
               .NotEmpty()
               .WithMessage("Marka Adı Boş Olamaz");


        }
    }
}
