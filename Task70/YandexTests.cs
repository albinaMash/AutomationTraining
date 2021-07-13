using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using Task70.YandexPages;

namespace Task70
{
    [TestFixture]
    [Parallelizable]
    [TestFixture("MicrosoftEdge", "latest", "Windows 10")]
    [TestFixture("firefox", "55.0", "Windows 8.1")]
    [TestFixture("chrome", "latest", "macOS 10.13")]
    public class Tests: Base
    {
        public Tests(string browser, string version, string os) : base(browser, version, os)
        {
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
    }
}