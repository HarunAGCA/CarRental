using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UpdateCarDtoValidator:AbstractValidator<UpdateCarDto>
    {
        public UpdateCarDtoValidator()
        {
            RuleFor(o => o.Id)
                .NotEmpty()
                .WithMessage("Id Boş Olamaz");

            RuleFor(o => o.Name)
                .NotEmpty()
                .WithMessage("Araç Adı Boş Olamaz");

            RuleFor(o => o.DailyPrice)
                .GreaterThanOrEqualTo(50)
                .WithMessage("Günlük Ücret 50 TL ve Üzeri Olmalıdır");

            RuleFor(o => o.BrandId)
                .NotEmpty()
                .WithMessage("Marka Boş Olamaz");

            RuleFor(o => o.ColorId)
                .NotEmpty()
                .WithMessage("Renk Boş Olamaz");

            RuleFor(o => o.Description)
                .NotEmpty()
                .WithMessage("Açıklama Boş Olamaz");

            RuleFor(o => o.ModelYear)
                .NotEmpty()
                .WithMessage("Model Yılı Boş Olamaz");
        }
    }
}
