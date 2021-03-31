using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).EmailAddress().WithMessage("Mail Adresi Geçersiz");
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Ad Boş Olamaz");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyad Boş Olamaz");
        }
    }
}
