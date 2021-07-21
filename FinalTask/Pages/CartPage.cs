using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using Allure.NUnit.Attributes;
using OpenQA.Selenium.Support.UI;
using System;

namespace FinalTask.Pages
{
    class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "total_product")]
        public IWebElement TotalProductsPrice
        {
            get; set;
        }

        [AllureStep("Check that total products price is returened")]
        public void CheckTotalPrice()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("total_product")));
            Assert.IsNotNull(TotalProductsPrice, "Total price is empty");
        }
    }
}
