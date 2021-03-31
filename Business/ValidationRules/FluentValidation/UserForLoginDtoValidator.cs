using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserForLoginDtoValidator:AbstractValidator<UserForLoginDto>
    {
        public UserForLoginDtoValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Mail Adresi Geçersiz");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Şifre Boş Olamaz");
        }
    }
}
