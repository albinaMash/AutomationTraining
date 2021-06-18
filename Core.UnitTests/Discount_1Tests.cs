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
            Assert.AreEqual(69.3, discount_1.PercentageValue(price));
        }
    }
}