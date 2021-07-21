using NUnit.Framework;
using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using FinalTask.Pages;

namespace FinalTask.Tests
{
    [TestFixture]
    [Parallelizable]
    [TestFixture("crome", "latest", "Windows 10")]
    [TestFixture("firefox", "latest", "Windows 10")]
    public class LoginTests : BaseTest
    {
        public LoginTests(string browser, string version, string os) : base(browser, version, os)
        {
        }

        LoginPage loginPage = new LoginPage(driver);

        [Test]
        [AllureSubSuite("Register new account")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("Account Page", "http://automationpractice.com/index.php?controller=authentication&back=my-account")]
        [AllureTest("Test new registration using unique email")]
        [AllureOwner("Albina Mashlyakevich")]
        public void Register_NewAccount_Test()
        {
            loginPage.Open();
            loginPage.EnterEmailAddress();
            loginPage.ClickCreateAccountButton();
            loginPage.FillOutNewAccountlInfo();
            loginPage.SubmitRegistrationForm();
            loginPage.VerifyNewAccountCreated();
        }

        [Test]
        [AllureSubSuite("Login")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureLink("Account Page", "http://automationpractice.com/index.php?controller=authentication&back=my-account")]
        [AllureTest("Test login process")]
        [AllureOwner("Albina Mashlyakevich")]
        public void Login_ToExistedAccount_Test()
        {
            loginPage.Open();
            loginPage.FillOutSigninForm();
            loginPage.SignIn();
            loginPage.VerifyUserSignedIn();
;        }
    }

}