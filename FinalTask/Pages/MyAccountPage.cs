using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System;
using Allure.NUnit.Attributes;

namespace FinalTask.Pages
{
    class MyAccountPage : BasePage
    {

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist']")]
        public IWebElement MyWishlistsLink
        {
            get; set;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='block_top_menu']/ul/li[2]/a")]
        public IWebElement MenuItemLink
        {
            get; set;
        }

        [AllureStep("Open My wishlist")]
        public MyWishlistsPage ClickMyWishlistsLink()
        {
            MyWishlistsLink.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement pageTitle = driver.FindElement(By.CssSelector("span.navigation_page"));
            string expectedPageTitle = "My wishlist";
            Assert.AreEqual(expectedPageTitle, pageTitle.Text, "Seems wishlist page is not opened");

            return new MyWishlistsPage(driver);
        }

        [AllureStep("Naviagte to category page")]
        public void ClickMenuItemLink()
        {
            MenuItemLink.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual("Dresses - My Store", driver.Title);
        }
    }
}
