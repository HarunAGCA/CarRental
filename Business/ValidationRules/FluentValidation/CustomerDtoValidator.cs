using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CustomerDtoValidator:AbstractValidator<Customer>
    {
        public CustomerDtoValidator()
        {
            RuleFor(c => c.CompanyName)
                .MinimumLength(2)
                .WithMessage("Firma Adı En Az 2 Karakter Olmalıdır");

            RuleFor(c => c.UserId)
                .NotEmpty();
        }
    }
}
