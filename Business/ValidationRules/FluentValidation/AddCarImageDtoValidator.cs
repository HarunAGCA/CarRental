using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class AddCarImageDtoValidator:AbstractValidator<AddCarImageDto>
    {
        public AddCarImageDtoValidator()
        {
            RuleFor(o => o.CarId).NotEmpty().WithMessage("Araç Id Boş Olamaz"); 
            RuleFor(o => o.Images).NotEmpty().WithMessage("En Az Bir Fotoğraf Seçilmeli");
        }
    }
}
