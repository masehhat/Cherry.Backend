using Cherry.Domain.FoodAggregate;

namespace Cherry.Application.FoodApplication.Views
{
    public class RestaurantView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public FoodView[] Foods { get; set; }
    }
}