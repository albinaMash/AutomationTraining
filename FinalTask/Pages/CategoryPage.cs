using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using Allure.NUnit.Attributes;
using OpenQA.Selenium.Interactions;

namespace FinalTask.Pages
{
    class CategoryPage : BasePage
    {
        private string cartPageUrl = "http://automationpractice.com/index.php?controller=order";

        public CategoryPage(IWebDriver driver) : base (driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "span.cross")]
        public IWebElement CloseButton
        {
            get; set;
        }

        [FindsBy(How = How.CssSelector, Using = "a[title = 'View my shopping cart']")]
        public IWebElement Cart
        {
            get; set;
        }

        [AllureStep("Add desired three items to the cart")]
        public void AddThreeItemsToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element1 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[text() = 'Add to cart']")));

            Actions hover = new Actions(driver);
            hover.MoveToElement(element1).Click();
            CloseButton.Click();
            Assert.False(CloseButton.Displayed, "Seems modal window is not closed");

            var element2 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[2]/div/div[2]/div[2]/a[1]/span")));
            hover.MoveToElement(element2).Click();
            CloseButton.Click();
            Assert.False(CloseButton.Displayed, "Seems modal window is not closed");

            var element3 = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[3]/div/div[2]/div[2]/a[1]/span")));
            hover.MoveToElement(element3).Click();
            CloseButton.Click();
            Assert.False(CloseButton.Displayed, "Seems modal window is not closed");
        }

        [AllureStep("Check that Cart icon contains the count of added items")]
        public void CheckAddedItems()
        {
            Actions hover = new Actions(driver);
            hover.MoveToElement(Cart);

            var itemsCount = driver.FindElement(By.CssSelector("span.ajax_cart_quantity"));
            Assert.AreEqual("3", itemsCount.Text, "Items actual count displayed on the icon does not correspond to added");
        }

        [AllureStep("Click cart icon in order to open cart page and check total")]
        public CartPage OpenCartPage()
        {
            Cart.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual(cartPageUrl, driver.Url, "Seems the page is not opened");
            return new CartPage(driver);
        }
    }
}
