using Cherry.Domain.FoodAggregate;
using Cherry.Infrastructure.Persistance;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.FoodApplication.Commands.RestaurantCommands
{
    public class AddFoodToMenuCommandHandler : IRequestHandler<AddFoodToMenuCommand, int>
    {
        private readonly CherryDbContext _context;

        public AddFoodToMenuCommandHandler(CherryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddFoodToMenuCommand request, CancellationToken cancellationToken)
        {
            Food food = new Food(request.RestaurantId, request.Name, request.Price);

            _context.Foods.Add(food);

            await _context.SaveChangesAsync();

            return food.Id;
        }
    }
}