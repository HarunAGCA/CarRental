using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class AddCarDtoValidator:AbstractValidator<AddCarDto>
    {
        public AddCarDtoValidator()
        {
            RuleFor(o => o.Name)
                .NotEmpty();

            RuleFor(o => o.DailyPrice)
                .GreaterThanOrEqualTo(10);

            RuleFor(o => o.BrandId)
                .NotEmpty();

            RuleFor(o => o.ColorId)
                .NotEmpty();

            RuleFor(o => o.Description)
                .NotEmpty();

            RuleFor(o => o.ModelYear)
                .NotEmpty();

        }
    }
}
