using FluentValidation;


namespace ConsoleWeather.Validators
{
    // FluentValidation Framework Initialized
    class CityValidator : AbstractValidator<Location>
    {
        public CityValidator()
        {
            RuleFor(location => location.Name).NotEmpty();
            RuleFor(location => location.Name).Length(2,30);
        }

        //Possibility to add other validators in the future
    }
}
