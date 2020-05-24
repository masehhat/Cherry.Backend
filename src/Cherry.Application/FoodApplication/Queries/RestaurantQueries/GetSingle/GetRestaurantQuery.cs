using Cherry.Application.FoodApplication.Views;
using MediatR;

namespace Cherry.Application.FoodApplication.Queries.GetSingle
{
    public class GetRestaurantQuery : IRequest<RestaurantView>
    {
        public int RestaurantId { get; set; }
    }
}