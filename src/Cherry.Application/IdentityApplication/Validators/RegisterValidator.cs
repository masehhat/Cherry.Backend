using Cherry.Application.IdentityApplication.Commands.Register;
using FluentValidation;

namespace Cherry.Application.IdentityApplication.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name cant be null");
            RuleFor(x => x.FirstName).MaximumLength(32).WithMessage("First name lentgh should be less than 33 chars");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name cant be null");
            RuleFor(x => x.LastName).MaximumLength(32).WithMessage("Last name lentgh should be less than 33 chars");
        }
    }
}