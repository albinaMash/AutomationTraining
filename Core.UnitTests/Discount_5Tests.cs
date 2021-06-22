using NUnit.Framework;

namespace Core.UnitTests
{
    public class Discount_5Tests
    {
        [Test]
        public void PercentageValue_ReturnsPriceWithFivePercentsDiscount()
        {
            decimal price = 100;
            Discounts.Discount_5 discount_5 = new Discounts.Discount_5();
            var actualPrice = discount_5.PercentageValue(price);
            decimal expectedPrice = 95m;
            Assert.AreEqual(expectedPrice, actualPrice, $"The expected price is {expectedPrice} but was actually {actualPrice}");
        }
    }
}
