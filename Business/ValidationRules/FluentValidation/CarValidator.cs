using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).GreaterThan((short)0);
            RuleFor(c=> c.ColorId).GreaterThan((short)0);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo((short)1980);
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();


        }
    }
}
