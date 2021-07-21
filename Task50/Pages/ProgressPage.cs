using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace Task50
{
    class ProgressPage
    {
        private string url = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        private IWebDriver driver;
        private IWebElement downloadButton;
        private IWebElement percentText;

        public ProgressPage(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Navigate().GoToUrl(url);
        }

        public void RefreshPage()
        {
            downloadButton = driver.FindElement(By.Id("cricle-btn"));
            downloadButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            try { 
                percentText = driver.FindElement(By.XPath("//div[contains(text(), 50)]")); 
            }

            finally {
                driver.Navigate().Refresh(); 
            }

            percentText = driver.FindElement(By.XPath("//div[contains(text(), 0)]"));

            Assert.IsTrue(percentText.Displayed, "It seems page is not refreshed");
        }
    }
}