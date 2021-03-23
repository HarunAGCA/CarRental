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
            RuleFor(o => o.Id).NotEmpty();
            RuleFor(o => o.Image).NotEmpty();
        }
    }
}
