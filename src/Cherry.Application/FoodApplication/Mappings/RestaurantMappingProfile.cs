using AutoMapper;
using Cherry.Application.FoodApplication.Views;
using Cherry.Domain.FoodAggregate;

namespace Cherry.Application.FoodApplication.Mappings
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantView>();

            CreateMap<Restaurant, RestaurantShortView>();
        }
    }
}