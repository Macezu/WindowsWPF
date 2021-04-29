using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWeather.Validators
{
    class CityValidator : AbstractValidator<Location>
    {
        public CityValidator()
        {
            RuleFor(location => location.CityName).NotEmpty();
            RuleFor(location => location.CityName).MinimumLength(2);
        }
    }
}
