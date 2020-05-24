using Cherry.Domain.FoodAggregate;
using MediatR;

namespace Cherry.Application.FoodApplication.Commands.RestaurantCommands
{
    public class RestaurantCreateCommand : IRequest<int>
    {
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}