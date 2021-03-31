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
                .GreaterThan(0)
                .WithMessage("RentalId Geçersiz");

            RuleFor(o => o.ReturnDate)
                .NotEmpty()
                .WithMessage("Teslim Tarihi Boş Olamaz");

            

        }
    }
}
