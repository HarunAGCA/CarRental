using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalUpdateDtoValidator:AbstractValidator<RentalUpdateDto>
    {
        public RentalUpdateDtoValidator()
        {
            RuleFor(r => r.RentDate)
              .NotEmpty()
              .WithMessage("Kiralama Tarihi Boş Olamaz");

            RuleFor(r => r.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerId Boş Olamaz");

            RuleFor(r => r.CarId)
                .NotEmpty()
                .WithMessage("CarId Boş Olamaz");
        }
    }
}
