﻿using NUnit.Framework;
using Core;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Core.UnitTests
{
    public class ValueCalculatorTests 
    {
        [Test]
        public void ValueCalc_ReturnsSumOfProductPrices()
        {
            ValueCalculator valueCalculator = new ValueCalculator();
            Product lays = new Product
            {
                Price = 34
            };
            Product cola = new Product
            {
                Price = 76
            };
            Product pizza = new Product
            {
                Price = 53
            };
            var prices = new List<Product>
            {
                lays,
                cola,
                pizza
            };
            IEnumerable<Product> products = prices.AsEnumerable();
            var sumofPrices = valueCalculator.ValueCalc(products);
            Assert.AreEqual(163, sumofPrices, $"The method should return 163 as the price of specified products but actually returned {sumofPrices}");
        }
    }
}