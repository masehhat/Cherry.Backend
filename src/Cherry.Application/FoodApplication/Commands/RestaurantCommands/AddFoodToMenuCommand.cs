using Cherry.Domain.Common;
using MediatR;

namespace Cherry.Application.FoodApplication.Commands.RestaurantCommands
{
    public class AddFoodToMenuCommand : IRequest<int>
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
    }
}