using Cherry.Application.Common.Structures;
using Cherry.Application.FoodApplication.Views;
using MediatR;

namespace Cherry.Application.FoodApplication.Queries.RestaurantQueries.GetAll
{
    public class GetAllRestaurantsQuery : PagedQuery, IRequest<PagedData<RestaurantShortView>>
    {
        public string Phrase { get; set; }
    }
}