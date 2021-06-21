using NUnit.Framework;
using Core;

namespace Core.UnitTests
{
    public class ProductTests
    {
        [Test]
        public void ToString_ReturnsCorrectProductInfo()
        {
            Product product = new Product
            {
                Name = "Lays",
                Price = 56,
                ProductID = 1
            };
            var productInfo = product.ToString();
            Assert.AreEqual("Product ID: 1, Name: Lays, Price: 56", productInfo, "Actual product info provided by overridden ToString method is not correct");
        }
        [Test]
        public void Equals_ReturnsFalseIfNoProduct()
        {
            Product product = new Product();
            Assert.IsFalse(product.Equals(null), "The second object exists");
        }
        [Test]
        public void Equals_ReturnsTrueIfSomeProductExists()
        {
            Product someProduct = new Product();
            Assert.IsTrue(someProduct.Equals(someProduct), "The second object is missed");
        }
        [Test]
        public void Equals_ReturnsNotEmptyProduct()
        {
            Product product = new Product
            {
                ProductID = 1,
                Price = 344,
                Name = "Candy"
            };
            Assert.IsNotNull(product.Equals(product), "Some object is not specified");
        }
        [Test]
        public void GetHasCode_ReturnsHashCodeForProduct()
        {
            Product product = new Product
            {
                ProductID = 8,
                Price = 30,
                Name = "Kinder"
            };
            Assert.NotNull(product.GetHashCode(), "The method did not return hashCode");
        }
    }
}