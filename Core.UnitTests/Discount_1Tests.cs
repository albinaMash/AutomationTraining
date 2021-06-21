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
            var priceWithDiscount = discount_1.PercentageValue(price);
            Assert.AreEqual(69.3, priceWithDiscount, $"The expected price is 69.3 but was actually {priceWithDiscount}");
        }
    }
}