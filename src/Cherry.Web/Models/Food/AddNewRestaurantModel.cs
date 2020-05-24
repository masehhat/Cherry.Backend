using Cherry.Domain.FoodAggregate;

namespace Cherry.Web.Models.Food
{
    public class AddNewRestaurantModel
    {
        public string Name { get; set; }
        public City City { get; set; }
        public string Street { get; set; }
        public string Alley { get; set; }
        public byte No { get; set; }
    }
}