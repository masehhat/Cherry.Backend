using Cherry.Application.FoodApplication.Commands.RestaurantCommands;
using FluentValidation;

namespace Cherry.Application.FoodApplication.Validators
{
    public class RestaurantValidator : AbstractValidator<RestaurantCreateCommand>
    {
        public RestaurantValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Restaurant should have a name");
            RuleFor(x => x.Name).MaximumLength(32).WithMessage("Name lentgh should be less than 33 chars");
        }
    }
}