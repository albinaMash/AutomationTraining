using Allure.Commons;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Task70.YandexPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Task70
{
    [TestFixture]
    public class Tests: AllureReport
    {
        private IWebDriver driver { get; set; }
        private string nodeURL;

        [OneTimeSetUp]
        public void SetupForAllure()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(GetType().Assembly.Location);
        }

        [SetUp]
        public void Setup()
        {
            nodeURL = "http://localhost:4444/wd/hub";
            DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
            desiredCapabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            desiredCapabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));
            desiredCapabilities.SetCapability(CapabilityType.BrowserName, "firefox");
            desiredCapabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.WinNT));
            driver = new RemoteWebDriver(new Uri(nodeURL), desiredCapabilities);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        [AllureSubSuite("Login Tests")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("Home Page", "https://yandex.by/")]
        [AllureTest("Test logins to Yandex using specified credentials")]
        [AllureOwner("Albina Mashlyakevich")]
        public void LoginTest()
        {
            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = new LoginPage(driver);
            PasswordPage passwordPage = new PasswordPage(driver);
         
            homePage.Open();
            homePage.ClickSigninButton();
            loginPage.EnterUsername("seleniumtests@tut.by");
            loginPage.ClickLoginButton();
            passwordPage.EnterPassword("123456789zxcvbn");
            passwordPage.ClickLoginButton();
            homePage.TakeScreenshot("Login Test");
        }

        [Test]
        [AllureSubSuite("Logout Tests")]
        [AllureSeverity(SeverityLevel.Normal)]
        [AllureLink("Home Page", "https://yandex.by/")]
        [AllureTest("Test logouts from Yandex and takes screenshot of Home Page after logout")]
        [AllureOwner("Albina Mashlyakevich")]
        [AllureStep("Try login using credentials (&username&, &password&)")]
        public void LogoutTest()
        {
            HomePage homePage = new HomePage(driver);
            
            homePage.Open();
            homePage.Login("seleniumtests@tut.by", "123456789zxcvbn");
            homePage.ClickUsernameLink();
            homePage.ClickSignoutButton();
            homePage.TakeScreenshot("Logout Test");
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.FailCount > 0)
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