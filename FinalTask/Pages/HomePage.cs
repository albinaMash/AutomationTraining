using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;
using System;
using Allure.NUnit.Attributes;
using OpenQA.Selenium.Support.UI;

namespace FinalTask.Pages
{
    class HomePage : BasePage
    {
        private string url = "http://automationpractice.com/index.php";
        private string expectedPageTitle = "My Store";
        private string loginPageUrl = "http://automationpractice.com/index.php?controller=authentication&back=my-account";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "a[class='login']")]
        public IWebElement SigninButton
        {
            get; set;
        }

        [AllureStep("Try to open home page")]
        public void Open()
        {
            driver.Navigate().GoToUrl(url);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementExists((By.TagName("title"))));
            Assert.AreEqual(expectedPageTitle, driver.Title, "Home page is not opened");
        }

        [AllureStep("Click sign in")]
        public LoginPage ClickSigninButton()
        {
            SigninButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual(loginPageUrl, driver.Url, "Seems Login page is not opened");
            return new LoginPage(driver);
        }
    }
}
