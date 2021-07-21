using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using FinalTask.AutomationResources;
using FinalTask.Pages;

namespace FinalTask.Tests
{
    [TestFixture]
    public class BaseTest
    {
        public static IWebDriver driver;
        protected string browser;
        protected string version;
        protected string os;

        WebDriverFactory driverFactory = new WebDriverFactory();

        public BaseTest(string browser, string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }

        [OneTimeSetUp]
        public void SetupForEachClass()
        {
            driverFactory.CreateSauceDriver(browser, version, os);

            //My version of switch the code to run tests locally/ using Selenium Grid/SauceLabs
            //driverFactory.CreateSeleniumGridDriver();
            //driverFactory.CreateChromeDriver();
            //driverFactory.CreateFirefoxDriver();
        }

        [TearDown]
        public void CleanUpForEachMethod()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
            {
                TakeScreenshot("Test is failed");
            }

            //Open new tab for the next test in test class
            IWebElement body = driver.FindElement(By.TagName("body"));
            body.SendKeys(Keys.Control + 't');
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Close();
            if (driver != null)
            {
                driver.Quit();
            }
        }

        public void TakeScreenshot(string reason)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            var fileName = @"Screenshot " + reason + "_"+ browser +"_"+ os +"_" + DateTime.Now.ToString("HH_mm_ss") + ".png";
            var fileLocation = Path.Combine(@"D:\Screenshots\", fileName);

            screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
        }
    }
}
