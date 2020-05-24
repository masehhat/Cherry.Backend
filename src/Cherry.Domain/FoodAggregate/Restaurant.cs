using System;
using System.Collections.Generic;

namespace Cherry.Domain.FoodAggregate
{
    public class Restaurant
    {
        //For EF core
        private Restaurant() { }

        public Restaurant(string name, Address address)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            if (name.Length > 32)
                throw new ArgumentOutOfRangeException("name", "lentgh should be less than 33 chars");

            Name = name;
            Address = address;
        }

        public int Id { get; }

        public string Name { get; }

        public Address Address { get; private set; }

        public ICollection<Food> Foods { get; }

        public void ChangeAddress(Address address)
        {
            Address = address;
        }
    }
}