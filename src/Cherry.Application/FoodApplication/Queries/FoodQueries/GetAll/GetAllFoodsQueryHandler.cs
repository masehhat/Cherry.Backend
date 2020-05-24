using Cherry.Application.Common.Helpers;
using Cherry.Application.Common.Structures;
using Cherry.Application.FoodApplication.Views;
using Cherry.Infrastructure.Persistance;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.FoodApplication.Queries.FoodQueries.GetAll
{
    public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, PagedData<FoodShortView>>
    {
        private readonly CherryDbContext _context;

        public GetAllFoodsQueryHandler(CherryDbContext context)
        {
            _context = context;
        }

        public async Task<PagedData<FoodShortView>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<FoodShortView> foods = _context.Foods.Join(_context.Restaurants, f => f.RestaurantId, r => r.Id,
                (f, r) => new FoodShortView
                {
                    FoodName = f.Name,
                    Price = f.Price.Value,
                    RestaurantName = r.Name
                });

            if (!string.IsNullOrWhiteSpace(request.Phrase))
                foods = foods.Where(x => x.FoodName.Contains(request.Phrase));

            return await foods.ToPagedDataAsync(request.PageNumber, request.PageSize, x => x, x => x.FoodName);
        }
    }
}