using Cherry.Domain.FoodAggregate;
using System;
using Xunit;

namespace Cherry.Domain.Test.FoodTests
{
    public class AddressShould
    {
        [Theory]        
        [InlineData(City.Karaj, "", "Rahimi", 63)]
        [InlineData(City.Qom, "Shariati", "", 10)]
        public void AddressShouldRaiseNullException(City city, string street, string alley, byte no)
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() =>
            {
                Address address = new Address(city, street, alley, no);
            });
        }

        [Theory]
        [InlineData(City.Karaj, "Lorem ipsum dolor", "rahimi", 63)]
        [InlineData(City.Qom, "Shariati", "Lorem ipsum dolor", 10)]
        public void AddressShouldRaiseOutOfRangeArgumentException(City city, string street, string alley, byte no)
        {
            Exception ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Address address = new Address(city, street, alley, no);
            });
        }

        [Fact]                
        public void AddressShouldGetCorrectCity()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                Address address = new Address((City)6, "rahmani", "sevvom", 20);
            });

            Assert.Equal("city value is wrong", ex.Message);
        }

        [Fact]
        public void AddressShouldCreate()
        {
            Address address = new Address(City.Tehran, "iran zamin", "chharom", 36);
        }

        [Fact]
        public void EqualAddressesShouldBeEqual()
        {
            Address address1 = new Address(City.Tehran, "Enqelab", "Ordibehesht", 10);
            Address address2 = new Address(City.Tehran, "Enqelab", "Ordibehesht", 10);

            Assert.True(address1.Equals(address2));
        }
    }
}