using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class UpdateCarImageDtoValidator:AbstractValidator<UpdateCarImageDto>
    {
        public UpdateCarImageDtoValidator()
        {
            RuleFor(o => o.Id).NotEmpty().WithMessage("Id Boş Olamaz");
            RuleFor(o => o.Image).NotEmpty().WithMessage("En Az Bir Fotoğraf Seçilmeli");
        }
    }
}
