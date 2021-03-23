using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RentalAddDtoValidator:AbstractValidator<RentalAddDto>
    {
        public RentalAddDtoValidator()
        {
            RuleFor(o => o.CarId)
                   .GreaterThan((short)0);

            RuleFor(o => o.CustomerId)
                .GreaterThan((short)0);

            RuleFor(o => o.RentDate)
                .NotEmpty();
        }
    }
}
