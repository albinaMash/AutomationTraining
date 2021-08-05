using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;

namespace Task70
{
    [TestFixture]
    public class Base
    {
        public IWebDriver driver;
        protected string browser;
        protected string version;
        protected string os;
        private string sauceUsername = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
        private string sauceAccessKey = Environment.GetEnvironmentVariable("SAUCE_ACCESS_KEY");
        private TestContext TestContext { get; set; }
        public Base(string browser, string version, string os)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
        }

        [OneTimeSetUp]
        public void SetupForAllure()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability("browserName", browser);
            caps.SetCapability("platformName", os);
            caps.SetCapability("browserVersion", version);
            caps.SetCapability("name", TestContext.TestName);
            
            driver = new RemoteWebDriver(new Uri($"https://{sauceUsername}:{sauceAccessKey}@ondemand.eu-central-1.saucelabs.com:443/wd/hub"), caps);

        }


        [TearDown]
        public void CleanUp()
        {

            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                TakeScreenshot("Test is failed");
            }
            driver.Close();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        public void TakeScreenshot(string testCase)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                var fileName = @"Screenshot " + testCase + " " + DateTime.Now.ToString("HH_mm_ss") + ".png";
                var fileLocation = Path.Combine(@"D:\Screenshots\", fileName);

                screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}