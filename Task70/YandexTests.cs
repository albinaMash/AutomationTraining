using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using Task70.YandexPages;

namespace Task70
{
    [TestFixture]
    public class Tests
    {
        private ChromeDriver driver { get; set; }

        //Comment out this part due to error The SearchContext of the locator object cannot be null (Parameter 'locator') and driver declaration can not be static
        //HomePage homePage = new HomePage(driver);
        //LoginPage loginPage = new LoginPage(driver);
        //PasswordPage passwordPage = new PasswordPage(driver);

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void LoginTest()
        {
            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = new LoginPage(driver);
            PasswordPage passwordPage = new PasswordPage(driver);

            homePage.Open();
            homePage.TakeScreenshot("Login Test");
            homePage.ClickSigninButton();
            loginPage.EnterUsername("seleniumtests@tut.by");
            loginPage.ClickLoginButton();
            passwordPage.EnterPassword("123456789zxcvbn");
            passwordPage.ClickLoginButton();
        }

        [Test]
        public void LogoutTest()
        {
            HomePage homePage = new HomePage(driver);
           
            homePage.Open();
            homePage.Login("seleniumtests@tut.by", "123456789zxcvbn");
            homePage.ClickUsernameLink();
            homePage.ClickSignoutButton();
            homePage.TakeScreenshot("Logout Test");
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}