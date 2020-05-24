using Cherry.Application.OrderApplication.Commands;
using FluentValidation;
using System.Linq;

namespace Cherry.Application.OrderApplication.Validators
{
    public class OrderValidator : AbstractValidator<AddOrderCommand>
    {
        public OrderValidator()
        {
            RuleFor(x => x.FoodsAndCounts).NotNull().Must(x => x.Any());
        }
    }
}