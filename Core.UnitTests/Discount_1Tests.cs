using NUnit.Framework;

namespace Core.UnitTests
{
    public class Discount_1Tests
    {
        [Test]
        public void PercentageValue_ReturnsPriceWithOnePercentDiscount()
        {
            decimal price = 70;
            Discounts.Discount_1 discount_1 = new Discounts.Discount_1();
            var actualPrice = discount_1.PercentageValue(price);
            decimal expectedPrice = 69.3m;
            Assert.AreEqual(expectedPrice, actualPrice, $"The expected price is {expectedPrice} but was actually {actualPrice}");
        }
    }
}