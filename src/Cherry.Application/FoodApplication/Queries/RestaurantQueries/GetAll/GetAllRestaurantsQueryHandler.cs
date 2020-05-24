using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cherry.Application.Common.Helpers;
using Cherry.Application.Common.Structures;
using Cherry.Application.FoodApplication.Views;
using Cherry.Infrastructure.Persistance;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.FoodApplication.Queries.RestaurantQueries.GetAll
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, PagedData<RestaurantShortView>>
    {
        private readonly CherryDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRestaurantsQueryHandler(CherryDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PagedData<RestaurantShortView>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            IQueryable<RestaurantShortView> restaurants = _context.Restaurants
                .ProjectTo<RestaurantShortView>(_mapper.ConfigurationProvider);

            if (!string.IsNullOrWhiteSpace(request.Phrase))
                restaurants = restaurants.Where(x => x.Name.Contains(request.Phrase));

            return await restaurants.ToPagedDataAsync(request.PageNumber, request.PageSize,
                restaurant => restaurant,
                restaurant => restaurant.Id);
        }
    }
}