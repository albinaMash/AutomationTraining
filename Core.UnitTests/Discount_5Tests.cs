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
            var priceWithDiscount = discount_5.PercentageValue(price);
            Assert.AreEqual(95, priceWithDiscount, $"The expected price is 95 but was actually {priceWithDiscount}");
        }
    }
}
