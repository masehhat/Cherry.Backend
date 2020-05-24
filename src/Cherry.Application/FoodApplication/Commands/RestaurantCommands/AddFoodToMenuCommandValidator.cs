using Cherry.Application.Common.Exceptions;
using Cherry.Application.FoodApplication.Exceptions;
using Cherry.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.FoodApplication.Commands.RestaurantCommands
{
    public class AddFoodToMenuCommandValidator : IPipelineBehavior<AddFoodToMenuCommand, int>
    {
        private readonly CherryDbContext _context;

        public AddFoodToMenuCommandValidator(CherryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddFoodToMenuCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
        {
            var data = await _context.Restaurants.Include(x => x.Foods)
                .Where(x => x.Id == request.RestaurantId)
                .Select(x => new
                {
                    RestaurantId = x.Id,
                    IsExistsTitle = x.Foods.Any(x=>x.Name == request.Name.Trim())
                }).FirstOrDefaultAsync();

            if (data == null)
                throw new ItemNotFoundException("restaurant not found");

            if (data.IsExistsTitle)
                throw new TitleIsExistsException();

            int response = await next();

            return response;
        }
    }
}