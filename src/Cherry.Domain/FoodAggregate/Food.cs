using Cherry.Domain.Common;
using System;

namespace Cherry.Domain.FoodAggregate
{
    public class Food
    {
        //For EF core
        private Food()
        {
        }

        public Food(int restaurantId, string name, Price price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (name.Length > 32)
                throw new ArgumentOutOfRangeException("name");

            RestaurantId = restaurantId;
            Name = name;
            Price = price;
        }

        public int Id { get; set; }
        public int RestaurantId { get; }
        public string Name { get; }
        public Price Price { get; private set; }

        public void ModifyPrice(Price price)
        {
            Price = price;
        }
    }
}