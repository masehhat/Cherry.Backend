using Cherry.Domain.FoodAggregate;
using Cherry.Infrastructure.Persistance;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.FoodApplication.Commands.RestaurantCommands
{
    public class RestaurantCreateCommandHandler : IRequestHandler<RestaurantCreateCommand, int>
    {
        private readonly CherryDbContext _context;

        public RestaurantCreateCommandHandler(CherryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RestaurantCreateCommand request, CancellationToken cancellationToken)
        {
            Restaurant restaurant = new Restaurant(request.Name, request.Address);

            _context.Restaurants.Add(restaurant);

            await _context.SaveChangesAsync();

            return restaurant.Id;
        }
    }
}