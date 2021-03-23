using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RentalDeliverDtoValidator:AbstractValidator<RentalDeliverDto>
    {
        public RentalDeliverDtoValidator()
        {
            RuleFor(o=>o.RentalId)
                .GreaterThan((short)0);

            RuleFor(o => o.ReturnDate)
                .NotEmpty();

            

        }
    }
}
