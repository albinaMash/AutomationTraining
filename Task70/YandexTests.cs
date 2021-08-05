using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using Task70.YandexPages;

namespace Task70
{
    [TestFixture]
    public class Tests
    {
        private static ChromeDriver driver { get; set; }

        HomePage homePage = new HomePage(driver);
        LoginPage loginPage = new LoginPage(driver);
        PasswordPage passwordPage = new PasswordPage(driver);

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
            homePage.Open();
            homePage.ClickSigninButton();
            loginPage.EnterUsername("seleniumtests@tut.by");
            loginPage.ClickLoginButton();
            passwordPage.EnterPassword("123456789zxcvbn");
            passwordPage.ClickLoginButton();
            homePage.CheckUserIsLoggedin();
        }

        [Test]
        public void LogoutTest()
        {  
            homePage.Open();
            homePage.Login("seleniumtests@tut.by", "123456789zxcvbn");
            homePage.ClickUsernameLink();
            homePage.ClickSignoutButton();
            homePage.CheckUserIsSignedOut();
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}