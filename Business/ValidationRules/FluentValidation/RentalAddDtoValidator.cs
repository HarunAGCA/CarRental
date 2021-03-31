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
                   .GreaterThan(0)
                   .WithMessage("CarId Geçersiz");

            RuleFor(o => o.CustomerId)
                .GreaterThan(0)
                .WithMessage("CustomerId Geçersiz");

            RuleFor(o => o.RentDate)
                .NotEmpty()
                .WithMessage("Kiralama Tarihi Boş Olamaz");
        }
    }
}
