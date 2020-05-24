using AutoMapper;
using AutoMapper.QueryableExtensions;
using Cherry.Application.Common.Exceptions;
using Cherry.Application.FoodApplication.Views;
using Cherry.Domain.FoodAggregate;
using Cherry.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.FoodApplication.Queries.GetSingle
{
    public class GetRestaurantQueryHandler : IRequestHandler<GetRestaurantQuery, RestaurantView>
    {
        private readonly IMapper _mapper;
        private readonly CherryDbContext _context;

        public GetRestaurantQueryHandler(CherryDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<RestaurantView> Handle(GetRestaurantQuery request, CancellationToken cancellationToken)
        {
            RestaurantView restaurant = await _context.Restaurants
                .Include(x => x.Foods)
                .AsNoTracking()
                .Select(x => new RestaurantView
                {
                    Address = x.Address,
                    Id = x.Id,
                    Name = x.Name,
                    Foods = x.Foods.Select(f => new FoodView
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Price = f.Price.Value
                    }).ToArray()
                }).FirstOrDefaultAsync(x => x.Id == request.RestaurantId);

            if (restaurant == null)
                throw new ItemNotFoundException();

            return restaurant;            
        }
    }
}