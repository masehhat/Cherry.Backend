using Cherry.Domain.Common;
using Xunit;

namespace Cherry.Domain.Test.FoodTests
{
    public class PriceShould
    {
        [Fact]
        public void EqualPriceShouldBeEqual()
        {
            Price price1 = new Price(20);
            Price price2 = new Price(20);

            Assert.True(price1.Equals(price2));

            Assert.True(price1 == price2);
        }

        [Fact]
        public void DifferentPriceShouldBeDifferent()
        {
            Price price1 = new Price(20);
            Price price2 = new Price(25);

            Assert.True(!price1.Equals(price2));

            Assert.True(price1 != price2);
        }
    }
}