﻿using NUnit.Framework;
using Core;

namespace Core.UnitTests
{
    public class ShoppingCartTests
    {
        [Test]
        public void CalculateTotal_ReturnsSumOfPricesWithOnePercentDiscount()
        {
            Product[] products =
            {
                new Product { Price = 50 },
                new Product { Price = 60 }
            };
            Discounts.Discount_1 discount1 = new Discounts.Discount_1();
            ValueCalculator valueCalculator = new ValueCalculator();
            ShoppingCart shoppingCart = new ShoppingCart(discount1, valueCalculator) { Products = products};
            Assert.AreEqual(108.9, shoppingCart.CalculateTotal(), "Method did not return correct sum of produce prices with 1% discount");
        }
        [Test]
        public void CalculateTotal_ReturnsSumOfPricesWithFivePercentsDiscount()
        {
            Product[] products =
            {
                new Product { Price = 80 },
                new Product { Price = 110 }
            };
            Discounts.Discount_5 discount5 = new Discounts.Discount_5();
            ValueCalculator valueCalculator = new ValueCalculator();
            ShoppingCart shoppingCart = new ShoppingCart(discount5, valueCalculator) { Products = products };
            var sumWithDiscount = shoppingCart.CalculateTotal();
            Assert.AreEqual(180.5, sumWithDiscount, $"Expected sum with 5% discount is 180.5 but was actually {sumWithDiscount}");
        }

    }
}
