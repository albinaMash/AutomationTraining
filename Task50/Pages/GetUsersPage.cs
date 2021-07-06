using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task50
{
    class GetUserPage
    {
        private string url = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";
        private IWebDriver driver;
        private IWebElement getNewUserButton;

        public GetUserPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(url);
        }

        public void WaitForUserToBeDisplayed()
        {
            getNewUserButton = driver.FindElement(By.Id("save"));
            getNewUserButton.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            IWebElement userInfo = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='loading']/img")));

            Assert.IsNotNull(userInfo, "User info is still not displayed");
        }
    }
}
