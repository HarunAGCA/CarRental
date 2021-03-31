using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserForRegisterDtoValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterDtoValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("Mail Adresi Geçersiz");

            RuleFor(u => u.FirstName)
                .MinimumLength(2)
                .WithMessage("Ad En Az İki Karakter Olmalı");

            RuleFor(u => u.LastName)
                .MinimumLength(2)
                .WithMessage("Soyad En Az İki Karakter Olmalı"); ;

            RuleFor(u => u.Password)
                .MinimumLength(8)
                .WithMessage("Şifre En Az 8 Karakterden Oluşmalı");
        }
    }
}
